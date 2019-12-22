using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
 
{
   
    public int health;
    public GameObject Player;
    public int MAX_HEALTH;
    private bool invincible = false;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float invincibilityTime = 3f;
    public GameObject damageIndicator;
    public AudioSource Hitsound;
    public AudioSource Deathsound;
    public bool isDead = false;
    public GameObject  BossOne;
    public GameObject BossTwo;
    public Transform BossSpawnPoint;
    public GameObject Boss;

 
    Vector2 resetPosition;
    void Start()
    {  
       resetPosition = this.transform.position;
        damageIndicator.SetActive(false);

    }
    
        IEnumerator Invulnerability()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
  
    }
    // Enemy Collision detection and health loss
    void OnTriggerEnter2D(Collider2D col)
    {
        
    
            if (col.tag == "Checkpoint")
            {
                resetPosition = col.transform.position;
            }
        
        if (!invincible)
        {
            

            if (col.tag == "Enemy")
              
            {
          
                
                StartCoroutine(Invulnerability());
                LoseHealth();
                Invoke("resetInvulnerability", 2);

                
            }
            if(col.tag == "Boss")


            {


                StartCoroutine(Invulnerability());
                LoseHealth();
                Invoke("resetInvulnerability", 2);


            }
            if(col.tag == "Projectile")
            {
                StartCoroutine(Invulnerability());
                LoseHealth();
                Invoke("resetInvulnerability", 2);

            }
        }
      

    }   
    
        
 
    void Update()
    {
        if (health <= 0)
        {
            onDeath();
        }

        // General health code
        if (health > MAX_HEALTH)
        {
            health = MAX_HEALTH;
        }
        Debug.Log("Health Script:" + health.ToString());
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < MAX_HEALTH)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    //Lose Your Health
    void LoseHealth()
    {
        damageIndicator.SetActive(true);
        Hitsound.Play();
        health -= 1;
        Invoke("turnBigScaryThingOff", 0.5f);
    }

    void turnBigScaryThingOff()
    {
        damageIndicator.SetActive(false);
    }
    //Removes Invulnerability
    void resetInvulnerability()
    {
        invincible = false;
    }

    void onDeath()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "bossFight")
        {
            Boss = GameObject.FindWithTag("Boss");
            isDead = true;
            Player.transform.position = resetPosition;
            health = 5;
            Deathsound.Play();
            isDead = false;
            Destroy(Boss);
            Instantiate(BossOne, BossSpawnPoint.position, Quaternion.identity);

        }
        else
        {
            isDead = true;
            Player.transform.position = resetPosition;
            health = 5;
            Deathsound.Play();
            isDead = false;
        }
        
    }
   
}
