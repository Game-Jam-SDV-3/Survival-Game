using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DungeonCreator : MonoBehaviour
{
    public int dungeonWidth, dungeonLength;
    public int roomWidthMin, roomLengthmin;
    public int maxIterations;
    public int corridorWidth;
    public Material material;
    [Range(0.0f, 0.3f)]
    public float roomBottomCornerModifier;
    [Range(0.7f, 1.0f)]
    public float roomTopCornerModifier;
    [Range(0, 2)]
    public int roomOffset;
    public GameObject wallVertical, wallHorizontal;
    public List<GameObject> mobPrefabs;
    public int minMobsPerRoom = 1;
    public int maxMobsPerRoom = 3;
    public GameObject playerPrefab;
    public Transform mainCamera;

    private GameObject playerInstance;

    List<Vector3Int> possibleDoorVerticalPosition,
        possibleDoorHorizontalPosition,
        possibleWallHorizontalWallPosition,
        possibleWallVerticalPosition;

    void Start()
    {
        CreateDungeon();
    }

    public void CreateDungeon()
    {
        DestroyAllChildren();

        DungeonGenerator generator = new DungeonGenerator(dungeonWidth, dungeonLength);
        var listOfRooms = generator.CalculateDungeon(
            maxIterations,
            roomWidthMin,
            roomLengthmin,
            roomBottomCornerModifier,
            roomTopCornerModifier,
            roomOffset,
            corridorWidth);

        GameObject wallParent = new GameObject("WallParent");
        wallParent.transform.parent = transform;

        possibleDoorVerticalPosition = new List<Vector3Int>();
        possibleDoorHorizontalPosition = new List<Vector3Int>();
        possibleWallHorizontalWallPosition = new List<Vector3Int>();
        possibleWallVerticalPosition = new List<Vector3Int>();

        for (int i = 0; i < listOfRooms.Count; i++)
        {
            CreateMesh(listOfRooms[i].BottomLeftAreaCorner, listOfRooms[i].TopRightAreaCorner);
        }
        CreateWalls(wallParent);
        SpawnMobs(listOfRooms);
        SpawnPlayer(listOfRooms);
    }

    private void CreateWalls(GameObject wallParent)
    {
        foreach (var wallPosition in possibleWallHorizontalWallPosition)
        {
            CreateWall(wallParent, wallPosition, wallHorizontal);
        }

        foreach (var wallPosition in possibleWallVerticalPosition)
        {
            CreateWall(wallParent, wallPosition, wallVertical);
        }
    }

    private void CreateWall(GameObject wallParent, Vector3Int wallPosition, GameObject wallPrefab)
    {
        Instantiate(wallPrefab, wallPosition, Quaternion.identity, wallParent.transform);
    }

    private void SpawnMobs(List<Node> rooms)
    {
        foreach (var room in rooms)
        {
            int mobCount = UnityEngine.Random.Range(minMobsPerRoom, maxMobsPerRoom + 1);
            for (int i = 0; i < mobCount; i++)
            {
                if (mobPrefabs.Count > 0)
                {
                    Vector3 spawnPosition = new Vector3(
                        UnityEngine.Random.Range(room.BottomLeftAreaCorner.x + 1, room.TopRightAreaCorner.x - 1),
                        0,
                        UnityEngine.Random.Range(room.BottomLeftAreaCorner.y + 1, room.TopRightAreaCorner.y - 1)
                    );

                    Quaternion randomRotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0);
                    GameObject mobPrefab = mobPrefabs[UnityEngine.Random.Range(0, mobPrefabs.Count)];
                    Instantiate(mobPrefab, spawnPosition, randomRotation);
                }
            }
        }
    }
    private void SpawnPlayer(List<Node> rooms)
    {
        if (rooms.Count == 0 || playerPrefab == null) return;

        Vector3 spawnPosition = new Vector3(
            rooms[0].BottomLeftAreaCorner.x + 1,
            3,
            rooms[0].BottomLeftAreaCorner.y + 1
        );

        playerInstance = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        mainCamera.GetComponent<SmoothCamera>().target = playerInstance.transform;
        mainCamera.GetComponent<PlayerLook>().playerBody = playerInstance.transform;
        PlayerLook playerLook = playerInstance.GetComponent<PlayerLook>();
    }

    private void CreateMesh(Vector2Int bottomLeftCorner, Vector2Int topRightCorner)
    {
        Vector3 bottomLeftV = new Vector3(bottomLeftCorner.x, 0, bottomLeftCorner.y);
        Vector3 bottomRightV = new Vector3(topRightCorner.x, 0, bottomLeftCorner.y);
        Vector3 topLeftV = new Vector3(bottomLeftCorner.x, 0, topRightCorner.y);
        Vector3 topRightV = new Vector3(topRightCorner.x, 0, topRightCorner.y);

        Vector3[] vertices = new Vector3[]
        {
            topLeftV,
            topRightV,
            bottomLeftV,
            bottomRightV
        };

        Vector2[] uvs = new Vector2[vertices.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }

        int[] triangles = new int[]
        {
            0,
            1,
            2,
            2,
            1,
            3
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        GameObject dungeonFloor = new GameObject($"Mesh{bottomLeftCorner}", typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider), typeof(Rigidbody), typeof(NavMeshSurface));

        dungeonFloor.transform.position = Vector3.zero;
        dungeonFloor.transform.localScale = Vector3.one;
        dungeonFloor.GetComponent<MeshFilter>().mesh = mesh;
        dungeonFloor.GetComponent<MeshRenderer>().material = material;
        dungeonFloor.transform.parent = transform;

        MeshCollider meshCollider = dungeonFloor.GetComponent<MeshCollider>();
        meshCollider.convex = false;

        Rigidbody rb = dungeonFloor.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        NavMeshSurface navMeshSurface = dungeonFloor.GetComponent<NavMeshSurface>();
        navMeshSurface.collectObjects = CollectObjects.All;
        navMeshSurface.useGeometry = NavMeshCollectGeometry.RenderMeshes;
        navMeshSurface.BuildNavMesh();

        for (int row = (int)bottomLeftV.x; row <= (int)bottomRightV.x; row++)
        {
            var wallPosition = new Vector3(row, 0, bottomLeftV.z);
            AddWallPositionToList(wallPosition, possibleWallHorizontalWallPosition, possibleDoorHorizontalPosition);
        }

        for (int row = (int)topLeftV.x; row <= (int)topRightCorner.x; row++)
        {
            var wallPosition = new Vector3(row, 0, topRightV.z);
            AddWallPositionToList(wallPosition, possibleWallHorizontalWallPosition, possibleDoorHorizontalPosition);
        }

        for (int col = (int)bottomLeftV.z; col <= (int)topLeftV.z; col++)
        {
            var wallPosition = new Vector3(bottomLeftV.x, 0, col);
            AddWallPositionToList(wallPosition, possibleWallVerticalPosition, possibleDoorVerticalPosition);
        }

        for (int col = (int)bottomRightV.z; col <= (int)topRightV.z; col++)
        {
            var wallPosition = new Vector3(bottomRightV.x, 0, col);
            AddWallPositionToList(wallPosition, possibleWallVerticalPosition, possibleDoorVerticalPosition);
        }
    }

    private void AddWallPositionToList(Vector3 wallPosition, List<Vector3Int> wallList, List<Vector3Int> doorList)
    {
        Vector3Int point = Vector3Int.CeilToInt(wallPosition);

        if (wallList.Contains(point))
        {
            doorList.Add(point);
            wallList.Remove(point);
        }
        else
        {
            wallList.Add(point);
        }
    }

    private void DestroyAllChildren()
    {
        while(transform.childCount != 0)
        {
            foreach(Transform item in transform)
            {
                DestroyImmediate(item.gameObject);
            }
        }
    }
}
