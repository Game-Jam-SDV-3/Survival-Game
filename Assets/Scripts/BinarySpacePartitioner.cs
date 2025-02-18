using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BinarySpacePartitioner
{
    RoomNode rootNode;
    public RoomNode RootNode { get => rootNode; }
    private int DungeonWidth { get; }
    private int DungeonLength { get; }
    public BinarySpacePartitioner(int dungeonWidth, int dungeonLength)
    {
        DungeonWidth = dungeonWidth;
        DungeonLength = dungeonLength;
        this.rootNode = new RoomNode(new Vector2Int(0, 0), new Vector2Int(dungeonWidth, dungeonLength), null, 0);
    }

    public List<RoomNode> PrepareNodesCollection(int maxIterations, int roomWidthMin, int roomLengthmin)
    {
        Queue<RoomNode> graph = new Queue<RoomNode>();
        List<RoomNode> listToReturn = new List<RoomNode>();
        graph.Enqueue(this.rootNode);
        listToReturn.Add(this.rootNode);

        int iteration = 0;
        while (iteration < maxIterations && graph.Count > 0)
        {
            iteration++;
            RoomNode currentNode = graph.Dequeue();

            if (currentNode.Width >= roomWidthMin * 2 || currentNode.Length >= roomLengthmin * 2)
            {
                SplitTheSapce(currentNode, listToReturn, roomWidthMin, roomLengthmin, graph);
            }
        }

        return listToReturn;
    }

    private void SplitTheSapce(RoomNode currentNode, List<RoomNode> listToReturn, int roomWidthMin, int roomLengthmin, Queue<RoomNode> graph)
    {
        Line line = GetLineDividingSpace(currentNode.BottomLeftAreaCorner, currentNode.TopRightAreaCorner, roomWidthMin, roomLengthmin);

        RoomNode node1, node2;

        if (line.Orientation == Orientation.Horizontal)
        {
            node1 = new RoomNode(currentNode.BottomLeftAreaCorner,
                new Vector2Int(currentNode.TopRightAreaCorner.x, line.Coordinates.y),
                currentNode,
                currentNode.treeLayerIndex + 1);
            node2 = new RoomNode(new Vector2Int(currentNode.BottomLeftAreaCorner.x, line.Coordinates.y),
                currentNode.TopRightAreaCorner,
                currentNode,
                currentNode.treeLayerIndex + 1);
        }
        else
        {
            node1 = new RoomNode(currentNode.BottomLeftAreaCorner,
                new Vector2Int(line.Coordinates.x, currentNode.TopRightAreaCorner.y),
                currentNode,
                currentNode.treeLayerIndex + 1);
            node2 = new RoomNode(new Vector2Int(line.Coordinates.x, currentNode.BottomLeftAreaCorner.y),
                currentNode.TopRightAreaCorner,
                currentNode,
                currentNode.treeLayerIndex + 1);
        }

        AddNewNodeToCollecton(listToReturn, graph, node1);
        AddNewNodeToCollecton(listToReturn, graph, node2);
    }

    private void AddNewNodeToCollecton(List<RoomNode> listToReturn, Queue<RoomNode> graph, RoomNode node)
    {
        listToReturn.Add(node);
        graph.Enqueue(node);
    }

    private Line GetLineDividingSpace(Vector2Int bottomLeftAreaCorner, Vector2Int topRightAreaCorner, int roomWidthMin, int roomLengthmin)
    {
        Orientation orientation;
        bool lengthStatus = topRightAreaCorner.y - bottomLeftAreaCorner.y >= roomLengthmin * 2;
        bool widthStatus = topRightAreaCorner.x - bottomLeftAreaCorner.x >= roomWidthMin * 2;

        if (lengthStatus && widthStatus)
        {
            orientation = (Orientation)(Random.Range(0, 2));
        }
        else if (widthStatus)
        {
            orientation = Orientation.Vertical;
        }
        else
        {
            orientation = Orientation.Horizontal;
        }

        return new Line(orientation, GetCoordinatesForOrientation(orientation, bottomLeftAreaCorner, topRightAreaCorner, roomWidthMin, roomLengthmin));

    }

    private Vector2Int GetCoordinatesForOrientation(Orientation orientation, Vector2Int bottomLeftAreaCorner, Vector2Int topRightAreaCorner, int roomWidthMin, int roomLengthmin)
    {
        Vector2Int coordinates = Vector2Int.zero;

        if (orientation == Orientation.Horizontal)
        {
            coordinates = new Vector2Int(0, Random.Range(bottomLeftAreaCorner.y + roomLengthmin, topRightAreaCorner.y - roomLengthmin));
        }
        else
        {
            coordinates = new Vector2Int(Random.Range(bottomLeftAreaCorner.x + roomWidthMin, topRightAreaCorner.x - roomWidthMin), 0);
        }

        return coordinates;
    }
}
