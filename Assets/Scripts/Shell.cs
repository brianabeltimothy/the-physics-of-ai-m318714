using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    public float speed = 0f;
    public float ySpeed = 0f;
    public float mass = 1.0f;
    public float force = 1.0f;
    public float drag = 1.0f;
    public float gravity = -9.8f;
    public float gravityAcceleration;
    public float acceleration;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank" || col.gameObject.tag == "ground")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        acceleration = force / mass;
        speed += acceleration * 1;

        gravityAcceleration = gravity / mass;
    }

    void LateUpdate()
    {
        speed *= (1 - Time.deltaTime * drag);
        ySpeed += gravityAcceleration * Time.deltaTime;

        transform.Translate(0, ySpeed, speed * Time.deltaTime);   

        if (speed < 0.0f)
        {
            speed = 0.0f;
        }
    }
}
