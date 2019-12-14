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
        Instantiate(Rock,new Vector3(firepoint.position.x, firepoint.position.y, firepoint.position.z), Quaternion.identity);
        //this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(ShotPower, 0));
        /*Vector2 v = -transform.forward;
        Rock.GetComponent<Rigidbody2D>().AddForce(v * 100f); */

    }
}
