using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    // Node waypoint
    public List<Edge> edgeList = new List<Edge>();
    public Node path;
    GameObject id;

    public float g, h, f;

    public Node cameFrom;

    public Node(GameObject i)
    {
        id = i;
        path = null;
    }

    public GameObject GetID()
    {
        return id;
    }
}
