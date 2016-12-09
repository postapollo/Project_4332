using UnityEngine;
using System.Collections;

public class EnemyLaser : MonoBehaviour {

    public GameObject player_death_explosion;
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


    void OnTriggerEnter(Collider other) { 



            if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            GameObject clone = Instantiate(player_death_explosion, transform.position, transform.rotation) as GameObject;
            Destroy(clone, 2);
            gameController.GameOver(); // call game over on player death 
        }

        else
        {
            return; //we only want to destroy the asteroid if it is hit with player laser 
        }
    }
}
