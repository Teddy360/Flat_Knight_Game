using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShoot : MonoBehaviour {
    
    public int ShotPower;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
    { 
       rb.AddForce(transform.forward * -100f);
        print("");
    }
}
