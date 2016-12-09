using UnityEngine;
using System.Collections;

public class Crate_Script : MonoBehaviour
{

    public float spin;
    public Rigidbody crate_rb;
    public GameObject on_contact_player;



    void Start()
    {
        crate_rb = GetComponent<Rigidbody>();
        crate_rb.angularVelocity = Random.insideUnitSphere * 3;

    }

    void OnTriggerEnter(Collider other)
    {
        //  if (other.tag == "Player")
        //  {
        Destroy(gameObject);
        GameObject clone = Instantiate(on_contact_player, transform.position, transform.rotation) as GameObject;
        Destroy(clone, 2);



    }

}



/*
 * 
var explosionPosition = transform.position;
var explosionRadius: float = 10.0;
var colliders : Collider[] = Physics.OverlapSphere(explosionPosition, explosionRadius);
foreach (var col in colliders)
    {
      if (col.collider.tag == "enemy")
      {
        Destroy(col.collider.gameObject);
      }
    }

 * */
