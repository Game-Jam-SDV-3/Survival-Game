﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class StructureHelper
{
    public static List<Node> TraverseGraphToExtractLowestLeafes(RoomNode parentNode)
    {
        Queue<Node> nodesToCheck = new Queue<Node>();
        List<Node> listToReturn = new List<Node>();

        if (parentNode.ChildrenNodeList.Count == 0)
        {
            return new List<Node> { parentNode };
        }

        foreach(var child in parentNode.ChildrenNodeList)
        {
            nodesToCheck.Enqueue(child);
        }

        while(nodesToCheck.Count > 0)
        {
            Node currentNode = nodesToCheck.Dequeue();

            if(currentNode.ChildrenNodeList.Count == 0)
            {
                listToReturn.Add(currentNode);
            }
            else
            {
                foreach (var child in currentNode.ChildrenNodeList)
                {
                    nodesToCheck.Enqueue(child);
                }
            }
        }
        return listToReturn;

    }

    public static Vector2Int GenerateBottomLeftCornerBetween(
        Vector2Int boundaryLeftPoint, 
        Vector2Int boundaryRightPoint, 
        float pointModifier, 
        int offset)
    {
        int minX = boundaryLeftPoint.x + offset;
        int maxX = boundaryRightPoint.x - offset;
        int minY = boundaryLeftPoint.y + offset;
        int maxY = boundaryRightPoint.y - offset;

        return new Vector2Int(
            Random.Range(minX, (int)(minX + (maxX - minX) * pointModifier)), 
            Random.Range(minY, (int)(minY + (minY - minY) * pointModifier)));

    }

    public static Vector2Int GenerateTopRightCornerBetween(
        Vector2Int boundaryLeftPoint,
        Vector2Int boundaryRightPoint,
        float pointModifier,
        int offset)
    {
        int minX = boundaryLeftPoint.x + offset;
        int maxX = boundaryRightPoint.x - offset;
        int minY = boundaryLeftPoint.y + offset;
        int maxY = boundaryRightPoint.y - offset;

        return new Vector2Int(
            Random.Range((int)(minX + (maxX - minX) * pointModifier), maxX),
            Random.Range((int)(minY+(maxY - minY) * pointModifier), maxY));

    }
}