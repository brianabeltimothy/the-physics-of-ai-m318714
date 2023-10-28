using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShell : MonoBehaviour {

    public GameObject explosion;
    Rigidbody rb;

    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == "tank") {
            Debug.Log("Hit tank");
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    void Start() {

        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        //rb.velocity is a vector representing the current velocity of the game object. It defines both the speed and direction of movement in world space.
        this.transform.forward = rb.velocity;
    }
}
