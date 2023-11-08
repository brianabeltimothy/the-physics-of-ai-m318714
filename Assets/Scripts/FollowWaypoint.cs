using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    public float tankSpeed = 10.0f;
    public float rotationSpeed = 3.0f;
    GameObject tracker; 
    private float lookAhead = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }

    void ProgressTracker()
    {
        if(Vector3.Distance(tracker.transform.position, this.transform.position) > lookAhead) return;

        if(Vector3.Distance(tracker.transform.position, waypoints[currentWaypoint].transform.position) < 3)
        {
            currentWaypoint++;
        }

        if(currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }

        tracker.transform.LookAt(waypoints[currentWaypoint].transform);
        tracker.transform.Translate(0, 0, (tankSpeed + 2) * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        ProgressTracker();

        Quaternion lookAtWaypoint = Quaternion.LookRotation(tracker.transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookAtWaypoint, rotationSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, tankSpeed * Time.deltaTime);
    }
}
