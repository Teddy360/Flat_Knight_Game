using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        { 
        
         
                col.gameObject.GetComponent<Health>().health += 1;
                Player playerObj = col.gameObject.GetComponentInParent<Player>();
                //print("playerObj is " + col.gameObject.GetComponentInParent<Player>());
                playerObj.Heartsound.time = 1.2f;
                playerObj.Heartsound.Play();
                Debug.Log("heart script: " + col.gameObject.GetComponent<Health>().health.ToString());
                 Destroy(gameObject);
        }


    }
}