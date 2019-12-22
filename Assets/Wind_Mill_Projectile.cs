using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Mill_Projectile : MonoBehaviour {
    public Transform firepoint;
    public GameObject Rock;
    public int ShotPower;
    public GameObject FallingRock;
    public Transform fallspotone;
    public Transform fallspottwo;
    public Transform fallspotthree;
    public Transform fallspotfour;
    public Transform fallspotfive;
    public Transform fallspotsix;

    void Start()
    {
    
            InvokeRepeating("Shoot", .1f, 1f);
       
            InvokeRepeating("RainRocks", 1.0f, 2.0f);
      


    }
          
        
    
    void Shoot()
    {
        print("SHOOT SOMETHING");
        Instantiate(Rock, firepoint.position, firepoint.rotation);



    }
    void RainRocks()
    {
        Instantiate(FallingRock, fallspotone.position, fallspotone.rotation);
        Instantiate(FallingRock, fallspottwo.position, fallspottwo.rotation);
        Instantiate(FallingRock, fallspotthree.position, fallspotthree.rotation);
        Instantiate(FallingRock, fallspotfour.position, fallspotfour.rotation);
        Instantiate(FallingRock, fallspotfive.position, fallspotfive.rotation);
        Instantiate(FallingRock, fallspotsix.position, fallspotsix.rotation);
    }
}
