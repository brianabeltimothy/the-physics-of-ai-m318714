using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondsUpdate : MonoBehaviour
{
    float timeStartOffset = 0.0f;
    bool gotTimeStart = false;
    public float speed = 0.5f;

    void Update()
    {
        if (!gotTimeStart)
        {
            gotTimeStart = true;
            timeStartOffset = Time.realtimeSinceStartup;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, speed * (Time.realtimeSinceStartup - timeStartOffset) );
    }
}
