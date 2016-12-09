using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControllerScript : MonoBehaviour {

    //need to spawn game object 
    public GameObject enemy_Object;
    public GameObject enemy_Bomber;
    public GameObject enemy_Light;
    public GameObject hard_Asteroid;
    public GameObject huge_Asteroid;
    public GameObject crate_Object;
    public GameObject crate_copy;
    public Vector3 spawn_vector;
    

    public GUIText score;
    public int score_int; //score update
    public GUIText restart;
    public GUIText gameOver;
    public GUIText shield;
    public GUIText start;

    private bool playerAlive;
    private bool restartGame;


    public int asteroid_count;
    public float asteroid_wait;
    public float asteroid_wait_between_hard;
    public float new_game_wait;
    public float hard_asteroid_wait;
    public float waitForNextRound;
    public float waitForThirdRound;
   // public float waitForHugeAsteroid;

    void Start()
    {
        playerAlive = true;
        restartGame = false;
        restart.text = ""; //clear on start
        gameOver.text = "";
        shield.text = "";

        score_int = 0;
        ScoreUpdate();
        //call generic spawn for whole game
        StartCoroutine(Spawn());
        StartCoroutine(SpawnCrateTimer());
        StartCoroutine(SpawnHardAsteroids());
        StartCoroutine(ScoreBumper());

        

    }

    IEnumerator ScoreBumper()
    {
        while (playerAlive == true)
        {
            // increase score by 1 for every second alive 
            yield return new WaitForSeconds(1);
            score_int++;
            ScoreUpdate();
        }
    }

    public void GameOver()
    {
        gameOver.text = "GAME OVER!";
        playerAlive = false;
        restart.text = "Press Space to Restart";
        restartGame = true;
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(new_game_wait);
        while (playerAlive == true) //keep spawning waves
        {
            for (int i = 0; i < asteroid_count; i++)
            {
                Vector3 spawnPosition = new Vector3(spawn_vector.x, spawn_vector.y, Random.Range(spawn_vector.z, -spawn_vector.z));
                Quaternion spawnRotation = Quaternion.identity;
                GameObject clone = Instantiate(enemy_Object, spawnPosition, spawnRotation) as GameObject;
                yield return new WaitForSeconds(asteroid_wait);

                Destroy (clone, 5);

            }
            
            for (int j = 0; j < 3; j++)
            {
                Quaternion spawnRotation = Quaternion.identity;
                Vector3 spawnPosition2 = new Vector3(spawn_vector.x, spawn_vector.y, Random.Range(spawn_vector.z, -spawn_vector.z));
                GameObject clone2 = Instantiate(enemy_Light, spawnPosition2, spawnRotation) as GameObject;
                Destroy(clone2, 10);

                

            }
            yield return new WaitForSeconds(waitForNextRound);
            StartCoroutine(SpawnEnemyBomber());

            yield return new WaitForSeconds(waitForThirdRound);
            StartCoroutine(SpawnHugeAsteroid());



        }
    }

    IEnumerator SpawnEnemyBomber()
    {
        yield return new WaitForSeconds(2);
        Vector3 spawnPosition = new Vector3(spawn_vector.x, spawn_vector.y, Random.Range(spawn_vector.z, -spawn_vector.z));
        Quaternion spawnRotation = Quaternion.identity;
        GameObject clone3 = Instantiate(enemy_Bomber, spawnPosition, spawnRotation) as GameObject;
        //  yield return new WaitForSeconds(asteroid_wait);

        Destroy(clone3, 15);

    }


    IEnumerator SpawnHugeAsteroid()
    {
        yield return new WaitForSeconds(2);
        Vector3 spawnPosition = new Vector3(spawn_vector.x, spawn_vector.y, Random.Range(spawn_vector.z, -spawn_vector.z));
        Quaternion spawnRotation = Quaternion.identity;
        GameObject clone3 = Instantiate(huge_Asteroid, spawnPosition, spawnRotation) as GameObject;
        Destroy(clone3, 10);

    }


    void Update()
    {
        if (restartGame == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel(Application.loadedLevel); //ignore for now, even if obsolete 
              //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
    }

    IEnumerator SpawnHardAsteroids()
    {
        yield return new WaitForSeconds(hard_asteroid_wait);
        while (true)
        {
            for (int i = 0; i < asteroid_count; i++)
            {
                Vector3 spawnPosition = new Vector3(spawn_vector.x, spawn_vector.y, Random.Range(spawn_vector.z, -spawn_vector.z));
                Quaternion spawnRotation = Quaternion.identity;
                GameObject clone = Instantiate(hard_Asteroid, spawnPosition, spawnRotation) as GameObject;
                yield return new WaitForSeconds(asteroid_wait_between_hard);

                Destroy (clone, 6);
            }
            yield return new WaitForSeconds(5);
        }
    }

    void ScoreUpdate()
    {
        score.text = "Score: " + score_int;
    }

    public void ShieldReady()
    {
        shield.text = "Shield Ready!";
    }

    public void ShieldNotReady()
    {
        shield.text = "";
    }

    public void AddScore (int newScoreValue)
    {
        score_int += newScoreValue;
        ScoreUpdate();
    }

    public void CloseStartScreen()
    {
        start.text = "";
    }





    //crate spawn - after x time 
    IEnumerator SpawnCrateTimer()
    {                                       //update later
        while (true)
        {
            yield return new WaitForSeconds(5);
            SpawnCrate();
            yield return new WaitForSeconds(15); //10 seconds after spawning, will delete copy of crate
            Destroy(crate_copy);

        }
    }

    //crate spawn
    void SpawnCrate()
    {
        Vector3 spawnPosition = new Vector3(spawn_vector.x, spawn_vector.y, Random.Range(spawn_vector.z, -spawn_vector.z));
        Quaternion spawnRotation = new Quaternion();
        crate_copy = Instantiate(crate_Object, spawnPosition, spawnRotation) as GameObject;
    }


}
