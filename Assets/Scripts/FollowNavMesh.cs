using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowNavMesh : MonoBehaviour
{
    public GameObject waypointManager;
    public GameObject[] waypoints;
    GameObject currentNode;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waypointManager.GetComponent<WaypointManager>().waypoints;
        Time.timeScale = 5.0f;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }
 
    void GoToSkeleton()
    {
        agent.SetDestination(waypoints[0].transform.position);
    }

    void GoToBarracks()
    {
        agent.SetDestination(waypoints[2].transform.position);
    }

    void GoToHeli()
    {
        agent.SetDestination(waypoints[8].transform.position);
    }

    void GoToOIlDerick()
    {
        agent.SetDestination(waypoints[13].transform.position);
    }
}
