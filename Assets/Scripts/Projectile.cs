using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Transform firepoint;
    public GameObject Rock;
    public int ShotPower;
	void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.tag == "Floor")
        {
            
            Shoot();
        }
    }
	void Shoot()
    {
        print("SHOOT SOMETHING");
        Instantiate(Rock, firepoint.position, firepoint.rotation);

     

    }
}
