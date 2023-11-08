using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction { UNI, BI };
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WaypointManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public Link[] links;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
