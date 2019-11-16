using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{ public Vector2 recoil;
    public bool hitstate;
    public AudioSource hitSound;

    void Start()
    {
        hitstate = false;
    }

        void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {

            hitSound.Play();
            col.gameObject.GetComponent<EnemyHealth>().onDeath();
           
            }
          

         
    
            
            
               
            
           
        }
    }
    
