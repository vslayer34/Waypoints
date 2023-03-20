using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    // Node waypoint
    public List<Edge> edgeList = new List<Edge>();
    public Node path;
    GameObject id;

    public float xPosition, yPosition, zPosition;
    public float g, h, f;

    public Node cameFrom;

    public Node(GameObject i)
    {
        id = i;
        xPosition = i.transform.position.x;
        yPosition = i.transform.position.y;
        zPosition = i.transform.position.z;
        path = null;
    }

    public GameObject GetID()
    {
        return id;
    }
}
