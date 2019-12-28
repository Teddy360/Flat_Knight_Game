using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour {
    public float invincibilityTime = 10000f;
    private bool invincible = false;
    public int health;
    public GameObject Next_Phase;
    public AudioSource hit_sound;
    // Use this for initialization
    void Start() {


    }
    IEnumerator Invulnerability()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            OnDeath();
        }
    }

        void OnTriggerEnter2D(Collider2D col)
    {



            if (!invincible)
            {


                if (col.tag == "Blade")

                {

                    hit_sound.Play();
                    StartCoroutine(Invulnerability());
                    LoseHealth();
                    Invoke("resetInvulnerability", 2);


                }
            }


        }
       
    public void LoseHealth()
    {
        health -= 1;
    }
    void OnDeath ()
    {
    
        if(Next_Phase == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instantiate(Next_Phase, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
          
 
        
    }
    void resetInvulnerability()
    {
        invincible = false;
    }
}
