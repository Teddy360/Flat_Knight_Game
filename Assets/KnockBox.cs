using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBox : MonoBehaviour {

    public Player PlayerObject;


 void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            print("AddingForce");
            PlayerObject.isHit = true;
           // SetisHitFalse();            
        }
       
 }
   /*IEnumerator SetisHitFalse()
    //{
        print("removingforce");
        yield return new WaitForSeconds(.1f);
        PlayerObject.isHit = false;
   */ 
}
