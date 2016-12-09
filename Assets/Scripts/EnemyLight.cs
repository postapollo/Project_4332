using UnityEngine;
using System.Collections;

public class EnemyLight : MonoBehaviour {


    public int scoreValue;
    public GameObject shot;
    public Transform laser_spawn;
    public Transform laser_spawn2;
    public int fireRate;

    public GameObject enemyLightExplosion;
    public GameObject player_death_explosion;
    public ControllerScript gameController;

   

    // Use this for initialization
    void Start()
    {

        fire();
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


    IEnumerator fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject clone = Instantiate(shot, laser_spawn.position, laser_spawn.rotation) as GameObject;
            Destroy(clone, 6);  //longer wait, to avoid disappearing on screen
            GameObject clone2 = Instantiate(shot, laser_spawn2.position, laser_spawn2.rotation) as GameObject;
            Destroy(clone2, 6);
        }

    }


    void OnTriggerEnter(Collider other)
    {

      //  if (other.tag == "Laser")
      //  {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject clone = Instantiate(enemyLightExplosion, transform.position, transform.rotation) as GameObject;
            Destroy(clone, 2);

            //update score
            gameController.AddScore(scoreValue);



    //    }

         if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            GameObject clone2 = Instantiate(player_death_explosion, transform.position, transform.rotation) as GameObject;
            Destroy(clone2, 2);
            gameController.GameOver(); // call game over on player death 
        }

        else
        {
            return; //we only want to destroy the asteroid if it is hit with player laser 
        }
    }


}
