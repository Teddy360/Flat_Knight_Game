using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounce : MonoBehaviour
{
    
    public float BouncePower;
    void OnTriggerEnter2D(Collider2D col)
    {
         
        if(col.tag == "Floor")
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, BouncePower));
        }
    }
}
