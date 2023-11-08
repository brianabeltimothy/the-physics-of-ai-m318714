using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float tankSpeed = 10.0f;
    public float rotationSpeed = 3.0f;

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

        if(currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }

        Quaternion lookAtWaypoint = Quaternion.LookRotation(waypoints[currentWaypoint].transform.position - transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookAtWaypoint, rotationSpeed * Time.deltaTime);
        
        transform.Translate(0, 0, tankSpeed * Time.deltaTime);
    }
}
