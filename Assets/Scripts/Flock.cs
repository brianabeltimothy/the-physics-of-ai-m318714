using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public float speed;
    bool turning = false;

    void Start()
    {
        speed = Random.Range(FlockManager.flockManagerScript.minSpeed, FlockManager.flockManagerScript.maxSpeed);
    }

    void Update()
    {
        Bounds b = new Bounds(FlockManager.flockManagerScript.transform.position, FlockManager.flockManagerScript.swimLimit * 2);

        if(!b.Contains(transform.position))
        {
            turning = true;
        }
        else
            turning = false;

        if(turning)
        {
            Vector3 direction = FlockManager.flockManagerScript.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), FlockManager.flockManagerScript.rotationSpeed * Time.deltaTime);
        }
        else
        {
            if(Random.Range(1, 100) < 10)
            {
                speed = Random.Range(FlockManager.flockManagerScript.minSpeed, FlockManager.flockManagerScript.maxSpeed);
            }

            if(Random.Range(1, 100) < 10)
            {
                ApplyRules();
            }
        }

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = FlockManager.flockManagerScript.allFish;

        Vector3 vectorCentre = Vector3.zero;
        Vector3 vectorAvoid = Vector3.zero;
        float groupSpeed = 0.0f;
        float neighbourDistance;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                neighbourDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if(neighbourDistance <= FlockManager.flockManagerScript.neighborDistance)
                {
                    vectorCentre += go.transform.position;
                    groupSize++;

                    if(neighbourDistance < 1.0f)
                    {
                        vectorAvoid += this.transform.position - go.transform.position;
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    groupSpeed += anotherFlock.speed;
                }
            }
        }

        if(groupSize > 0)
        {
            vectorCentre = vectorCentre / groupSize + (FlockManager.flockManagerScript.goalPosition - this.transform.position); 
            speed = groupSpeed / groupSize;

            if(speed > FlockManager.flockManagerScript.maxSpeed)
            {
                speed = FlockManager.flockManagerScript.maxSpeed;
            }

            Vector3 newDirection = (vectorAvoid + vectorCentre) - transform.position;
            if(newDirection != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newDirection), FlockManager.flockManagerScript.rotationSpeed * Time.deltaTime);
        }
    }
}
