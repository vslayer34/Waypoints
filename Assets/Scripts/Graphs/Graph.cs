using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    // list of all nodes and eges
    List<Node> nodes = new List<Node>();
    List<Edge> edges = new List<Edge>();

    // The A* list
    List<Node> pathList = new List<Node>();

    // add node to the nodes list
    public void AddNode(GameObject id)
    {
        Node node = new Node(id);
        nodes.Add(node);
    }

    // add edge to edges list
    public void AddEdge(GameObject fromNode, GameObject toNode)
    {
        Node from = FindNode(fromNode);
        Node to = FindNode(toNode);

        if (from != null && to != null)
        {
            Edge edge= new Edge(from, to);
            edges.Add(edge);
            from.edgeList.Add(edge);
        }
    }

    Node FindNode(GameObject id)
    {
        foreach (Node node in nodes)
        {
            if (node.GetID() == id) { return node; }
        }
        return null;
    }

    float GetDistance(Node a, Node b)
    {
        return Vector3.SqrMagnitude(a.GetID().transform.position - b.GetID().transform.position);
    }

    int GetLowestFValue(List<Node> nodes)
    {
        float lowestFValue = 0;
        int count = 0;
        int iteratorCount = 0;

        lowestFValue = nodes[0].f;

        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].f <= lowestFValue)
            {
                lowestFValue = nodes[i].f;
                iteratorCount = count;
            }
            count++;
        }
        return iteratorCount;
    }

    public bool CalculateAStar(GameObject startId, GameObject endId)
    {
        Node start = FindNode(startId);
        Node end = FindNode(endId);

        if (start == null || end == null) { return false; }

        List<Node> open = new List<Node>();
        List<Node> closed = new List<Node>();
        float tentativeGScore;
        bool IsBetterTebtative;

        start.g = 0;
        start.h = GetDistance(start, end);
        start.f = start.h;

        open.Add(start);

        while (open.Count > 0)
        {
            int i = GetLowestFValue(open);
            Node node = open[i];

            if (node.GetID() == endId)
            {
                // ReconstructPath(start, end);
                return true;
            }

            open.RemoveAt(i);
            closed.Add(node);

            Node neighbour;
            foreach(Edge edge in node.edgeList)
            {
                neighbour = edge.endNode;

                if (closed.IndexOf(neighbour) > -1) { continue; }

                tentativeGScore = node.g + GetDistance(node, neighbour);

                if (open.IndexOf(neighbour) == -1)
                {
                    open.Add(neighbour);
                    IsBetterTebtative = true;
                }
                else if (tentativeGScore < neighbour.g)
                {
                    IsBetterTebtative = true;
                }
                else
                {
                    IsBetterTebtative = false;
                }

                if (IsBetterTebtative)
                {
                    neighbour.cameFrom = node;
                    neighbour.g = tentativeGScore;
                    neighbour.h = GetDistance(node, end);
                    neighbour.f = neighbour.g + neighbour.h;
                }
            }
        }

        return false;

    }   // CalculateAStar()
}   // Graph class
