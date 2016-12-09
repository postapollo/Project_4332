using UnityEngine;
using System.Collections;

public class Asteroid_Script : MonoBehaviour {

    public float spin;
    public Rigidbody asteroid_rb;

    void Start()
    {
        asteroid_rb = GetComponent<Rigidbody>();
        asteroid_rb.angularVelocity = Random.insideUnitSphere * 3 ;
    }
}
