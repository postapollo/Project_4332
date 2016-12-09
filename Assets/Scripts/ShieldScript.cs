using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

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
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
        }

    }



}
