using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public Transform[] waypoints;
    int currentWaypoint;
    float speed = 10.0f;
    float rotaionSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // check the distance to the waypoint so if it's reached the tank moves to the next waypoint
        float distance = Vector3.Distance(transform.position, waypoints[currentWaypoint].position);
        if (distance < 3.0f) { currentWaypoint++; }

        // reset the waypoints after the tank reach the final one
        if (currentWaypoint >= waypoints.Length) { currentWaypoint = 0; }

        Quaternion rotaionDirection = Quaternion.LookRotation(waypoints[currentWaypoint].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotaionDirection, rotaionSpeed * Time.deltaTime);

        transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }
}
