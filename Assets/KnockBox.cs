using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBox : MonoBehaviour {

    public Player PlayerObject;


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
         {
             print("AddingForce");
            //StartCoroutine(PlayerObject.Knockback(0.02f, 500, PlayerObject.transform.position - col.transform.position));
           // PlayerObject.Knockback(0.02f, 500, PlayerObject.transform.position - col.transform.position);
                        
         }

  }
    
    }


