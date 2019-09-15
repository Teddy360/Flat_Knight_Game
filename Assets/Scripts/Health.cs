using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
 
{
    public GameObject Heart;
    public int health;
    public int numOfHearts;
    private bool invincible = false;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float invincibilityTime = 3f;
    IEnumerator Invulnerability()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
  
    }
    // Enemy Collision detection and health loss
    void OnTriggerEnter2D(Collider2D col)
    {
       if (!invincible)
        {
            

            if (col.tag == "Enemy")
              
            {
          
                
                    StartCoroutine(Invulnerability());
                    LoseHealth();
                    Invoke("resetInvulnerability", 2);
               
                    if (col.gameObject.GetComponent<EnemyHealth>().isDeadEnemy) 
                
                {
                    float x = this.transform.position.x;
                    float y = this.transform.position.y;
                    Instantiate(Heart, new Vector3(x, y, 0), Quaternion.identity);
                    health += 1;
              
                    Destroy(col.gameObject);
                }

                
            }
        }
      

    }   
    
        
 
    void Update()
    {
       
        // General health code
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
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
            if (i < numOfHearts)
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
        
        health -= 1;
    }
    //Removes Invulnerability
    void resetInvulnerability()
    {
        invincible = false;
    }
}
