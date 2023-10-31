using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager flockManagerScript;
    public GameObject fishPrefab;
    public int fishNum = 20;
    public GameObject[] allFish;
    public Vector3 swimLimit = new Vector3(5,5,5); //this is the aquarium
    public Vector3 goalPosition = Vector3.zero;

    [Header("Fish Settings")]
    [Range(0.0f, 0.5f)]
    public float minSpeed;
    [Range(0.0f, 0.5f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighborDistance;
    [Range(1.0f, 0.5f)]
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        allFish = new GameObject[fishNum];
        for (int i = 0; i < fishNum; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimit.x, swimLimit.x), Random.Range(-swimLimit.y, swimLimit.y), Random.Range(-swimLimit.z, swimLimit.z));
            allFish[i] = Instantiate(fishPrefab, pos, Quaternion.identity);
        }
        flockManagerScript = this;
        goalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,100) < 10)
        {
            goalPosition = this.transform.position + new Vector3(Random.Range(-swimLimit.x, swimLimit.x), Random.Range(-swimLimit.y, swimLimit.y), Random.Range(-swimLimit.z, swimLimit.z));
        }
    }
}
