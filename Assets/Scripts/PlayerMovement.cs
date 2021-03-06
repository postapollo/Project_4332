﻿using UnityEngine;
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



    public ControllerScript gameController;

    public float playerSpeed;
    public float tilt;
    public GameBoundary boundary;

    //primary weapon
    public GameObject shot;
    public Transform laser_spawn;
    public float fireRate;


    //secondary weapon
    public GameObject shield;
    int secondaryTimer = 2;
    private float nextFire;
    public bool on = false;
    public bool ready = false;


    public Rigidbody rb;
   // public SphereCollider collider;
    void Start()
    {
        StartCoroutine(ActivateShield());
        rb = GetComponent<Rigidbody>();

        //needed for shield 
        GameObject gameControllerOBject = GameObject.FindWithTag("GameController");
        if (gameControllerOBject != null)
        {
            gameController = gameControllerOBject.GetComponent<ControllerScript>();
        }
        else
        {
            //exit
        }

    }


    //done before updating the frame, every frame, primary fire
    void Update()
    {

        

        
        // ActivateShield();
        // var delay = 2.0;
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            gameController.CloseStartScreen();
            nextFire = Time.time + fireRate;
            GameObject clone = 
            Instantiate(shot, laser_spawn.position, laser_spawn.rotation) as GameObject;

            Destroy(clone, 2); //cannot destroy shot, that's the original game object
        }


        //    if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time > secondaryTimer) //should be greater than 2 
        //    {
        //   GameObject clone = Instantiate(shield, laser_spawn.position, laser_spawn.rotation) as GameObject;
        //   Destroy(clone, 2);
        //           shield.SetActive(true);
        //    }
  
        if (ready)
        {
            gameController.ShieldReady();
           if (Input.GetKey(KeyCode.Space))
            {
                
                ready = false;
                gameController.ShieldNotReady();
                GameObject clone =
                Instantiate(shield, laser_spawn.position, laser_spawn.rotation) as GameObject;
                

                Destroy(clone, 3);
                
                secondaryTimer += 2;
            }
        }
        else
        {
            
            //nothing happens when press Input.GetKey(KeyCode.Space))
        }
        
    }

    IEnumerator ActivateShield()
    {

        while (true)
        {
            //ActivateShield();
            yield return new WaitForSeconds(secondaryTimer);

            ready = true;
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
