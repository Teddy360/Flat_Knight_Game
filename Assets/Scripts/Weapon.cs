using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
  
 
    public AudioSource hitSound;
   


    void Start()
    {


    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log("Bladehit");
            hitSound.Play();
            col.gameObject.GetComponent<EnemyHealth>().onDeath();

        }

    }
   

}
    
