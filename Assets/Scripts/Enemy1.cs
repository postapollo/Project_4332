using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {


    public GameObject shot;
    public Transform laser_spawn;
    public Transform laser_spawn2;
    public int fireRate;



	// Use this for initialization
	void Start () {

        StartCoroutine(fire());
	
	}
	

	IEnumerator fire () {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject clone = Instantiate(shot, laser_spawn.position, laser_spawn.rotation) as GameObject;
            Destroy(clone, 6);  //longer wait, to avoid disappearing on screen
            GameObject clone2 = Instantiate(shot, laser_spawn2.position, laser_spawn2.rotation) as GameObject;
            Destroy(clone2, 6);
        }


        

	}




}
