using UnityEngine;
using System.Collections;

//David Dillard - created 10/26

    //to draw edges of game view 
    //must include so Unity can see this
    [System.Serializable]
public class GameBoundary
{
    public float xMin, xMax, zMin, zMax;

}


public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float playerSpeed;
    public float tilt;
    public GameBoundary boundary;

    public GameObject shot;
    public Transform laser_spawn;
    public float fireRate;

    private float nextFire;

   

    //done before updating the frame, every frame
    void Update()
    {
       // var delay = 2.0;
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = 
            Instantiate(shot, laser_spawn.position, laser_spawn.rotation) as GameObject;

            Destroy(clone, 2); //cannot destroy shot, that's the original game object
        }
    }


    //executed once per physics step
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); //player input
        rb.velocity = movement * playerSpeed;

        //set boundaries 
        rb.position = new Vector3
            (Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax));

        rb.rotation = Quaternion.Euler(0.0f, 90, rb.velocity.z * tilt);
                                        // x y z 
    }

}
