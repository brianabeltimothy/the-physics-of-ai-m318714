using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShell : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    void Update()
    {
        transform.Translate(0, speed * 0.5f * Time.deltaTime, speed * Time.deltaTime); 
    }
}
