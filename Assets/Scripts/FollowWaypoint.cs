using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWaypoint = 0;

    private float tankSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, waypoints[currentWaypoint].transform.position) < 3)
        {
            currentWaypoint++;
        }

        // if(currentWaypoint >= waypoints.Length())
        // {
        //     currentWaypoint = 0;
        // }

        // transform.position 
    }
}
