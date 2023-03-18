using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public Transform[] waypoints;
    int currentWaypoint;
    public float speed = 10.0f;
    public float rotaionSpeed = 3.0f;

    GameObject tracker;
    Vector3 clearness;
    float safeDistance = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
        clearness = transform.forward * safeDistance;
        
        // create tracker game object and set its initial position and rotation
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Destroy(tracker.GetComponent<BoxCollider>());
        
        tracker.transform.position = transform.position + clearness;
        tracker.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        TrackerProgress();

        Quaternion rotaionDirection = Quaternion.LookRotation(tracker.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotaionDirection, rotaionSpeed * Time.deltaTime);

        transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }

    void TrackerProgress()
    {
        if (Vector3.Distance(transform.position, tracker.transform.position) > safeDistance) { return; }

        // check the distance to the waypoint so if it's reached the tank moves to the next waypoint
        float distance = Vector3.Distance(tracker.transform.position, waypoints[currentWaypoint].position);
        if (distance < 0.5f) { currentWaypoint++; }

        // reset the waypoints after the tank reach the final one
        if (currentWaypoint >= waypoints.Length) { currentWaypoint = 0; }

        tracker.transform.LookAt(waypoints[currentWaypoint].position);
        tracker.transform.Translate(0.0f, 0.0f, 0.1f);
    }
}
