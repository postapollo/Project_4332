using UnityEngine;
using System.Collections;

public class Mover_Angular : MonoBehaviour {

    public Rigidbody rb;
   // public float speedX;
   // public float speedY;
    void Start()
    {
        int random = Random.Range(-4, 4);

        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-10, 0, random);
        //  rb.velocity = transform.forward * speedY;

        //   Vector2 dir = rb.velocity;
        //   float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //   transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }
}
