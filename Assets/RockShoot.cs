using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShoot : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
        }
       
    }
}
