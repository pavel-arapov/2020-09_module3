using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform previousWaypoint;
    public Transform nextWaypoint;
    public float speed;
    public Transform[] waypoints;
    public int waypointIndex = 0;

    private float current;  // от 0 до 1
    private float dir;

    void Start()
    {
        current = 0.0f;
        dir = 1.0f;
        previousWaypoint = waypoints[0];
        nextWaypoint = waypoints[1];
        waypointIndex = 1;
    }

    void Update()
    {
        current += dir * speed * Time.deltaTime;
        
        // find next waypoint if the current has been reached
        if (current > 1.0f) {
            current = 0.0f;
            previousWaypoint = waypoints[waypointIndex];
            waypointIndex = FindNextWayPoint(waypointIndex);
            nextWaypoint = waypoints[waypointIndex];
        } 
        
        transform.position = Vector3.Lerp(previousWaypoint.position, nextWaypoint.position, current);
    }

    private int FindNextWayPoint(int waypoint) {
        waypoint += 1;
        return (waypoint % waypoints.Length) == 0 ? 0 : waypoint;
    }
}

