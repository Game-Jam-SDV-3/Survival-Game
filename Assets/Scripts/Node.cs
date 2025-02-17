﻿using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    private List<Node> childrenNodeList;

    public List<Node> ChildrenNodeList { get => childrenNodeList; }

    public bool visited { get; set; }

    public Vector2Int BottomLeftAreaCorner { get; set; }
    public Vector2Int BottomRightAreaCorner { get; set; }
    public Vector2Int TopLeftAreaCorner { get; set; }
    public Vector2Int TopRightAreaCorner { get; set; }

    public int treeLayerIndex { get; set; }

    public Node parent;

    protected Node(Node parentNode)
    {
        childrenNodeList = new List<Node>();
        this.parent = parentNode;

        if (parent != null)
        {
            parentNode.AddChild(this);
        }
    }
    public void AddChild(Node node)
    {
        childrenNodeList.Add(node);
    }

    public void RemoveChild(Node node)
    {
        childrenNodeList.Remove(node);
    }
}