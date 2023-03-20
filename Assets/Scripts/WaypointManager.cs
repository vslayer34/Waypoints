using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Link
{
    public enum Directions { UNI, BI };
    public GameObject node1;
    public GameObject node2;
    public Directions direction;
}

public class WaypointManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public Link[] links;
    public Graph graph;

    // Start is called before the first frame update
    void Start()
    {
        graph = new Graph();

        if (waypoints.Length > 0)
        {
            foreach (GameObject waypoint in waypoints)
            {
                graph.AddNode(waypoint);
            }

            foreach (Link link in links)
            {
                graph.AddEdge(link.node1, link.node2);
                
                if (link.direction == Link.Directions.UNI) { graph.AddEdge(link.node2, link.node1); }


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
