using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShell : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime); 
    }
}