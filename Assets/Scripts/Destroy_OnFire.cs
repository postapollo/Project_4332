using UnityEngine;
using System.Collections;

public class Destroy_OnFire : MonoBehaviour {

    public int scoreValue;
    public GameObject player_death_explosion;
    public GameObject asteroid_explosion; //ref to our exp
    public ControllerScript gameController;

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
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject clone = Instantiate(asteroid_explosion, transform.position, transform.rotation) as GameObject;
            Destroy(clone, 2);

            //update score
            gameController.AddScore(scoreValue);
            


        }

        else if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            GameObject clone = Instantiate(player_death_explosion, transform.position, transform.rotation) as GameObject;
            Destroy (clone, 2);
            gameController.GameOver(); // call game over on player death 
        }

        else
        {
            return; //we only want to destroy the asteroid if it is hit with player laser 
        }
    }

}
