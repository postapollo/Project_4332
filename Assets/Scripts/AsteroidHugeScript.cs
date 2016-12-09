using UnityEngine;
using System.Collections;

public class AsteroidHugeScript : MonoBehaviour {

    public int scoreValue;
    public ControllerScript gameController;
    public GameObject asteroid_explosion;
    public GameObject asteroid_explosion2;
    public GameObject player_death_explosion;
    public GameObject asteroidBaby;
    public int asteroidBabyCount;

    public Vector3 offset = new Vector3(0, 0, 0);
    public Vector3 offset2 = new Vector3(0, 0, 0);
    public float offsetBump;
    public float offsetBump2;
    int health = 5;
    

    void Start()
    {
        
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


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Laser")
        {
            if (health != 0)
           {
                health--;
                Destroy(other.gameObject);
            }
            else
            {

                Destroy(other.gameObject);
                Destroy(gameObject);
                InstantiateAsteroidBaby(); //call to product a lot more astroids 
                GameObject clone = Instantiate(asteroid_explosion, transform.position, transform.rotation) as GameObject;
                Destroy(clone, 2);
                GameObject clone2 = Instantiate(asteroid_explosion2, transform.position, transform.rotation) as GameObject;
                Destroy(clone2, 2);

                //update score
                gameController.AddScore(scoreValue);
            }


        }

        else if (other.tag == "Shield")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            InstantiateAsteroidBaby(); //call to product a lot more astroids 
            GameObject clone = Instantiate(asteroid_explosion, transform.position, transform.rotation) as GameObject;
            Destroy(clone, 2);
            GameObject clone2 = Instantiate(asteroid_explosion2, transform.position, transform.rotation) as GameObject;
            Destroy(clone2, 2);

            //update score
            gameController.AddScore(scoreValue);
        }

        else if (other.tag == "Player")
        {
            
            Destroy(other.gameObject);
            GameObject clone = Instantiate(player_death_explosion, transform.position, transform.rotation) as GameObject;
            Destroy(clone, 2);
            gameController.GameOver(); // call game over on player death 
        }

        else
        {
            //  return; //we only want to destroy the asteroid if it is hit with player laser 
            Destroy(other.gameObject);


        }
    }



    void InstantiateAsteroidBaby()
    {
        for (int i =0; i< asteroidBabyCount; i++)
        {
            // Instantiate(asteroidBaby, transform.position, transform.rotation);
            GameObject clone1 = Instantiate(asteroidBaby, transform.position + offset, transform.rotation) as GameObject;
            GameObject clone2 = Instantiate(asteroidBaby, transform.position + offset2, transform.rotation) as GameObject;
            offset.z += Random.Range(-0.5f, 0.5f);
            offset2.x += Random.Range(-0.5f, 0.5f);

            Destroy(clone1, 4);
            Destroy(clone2, 4);
        }


      
    }

}
