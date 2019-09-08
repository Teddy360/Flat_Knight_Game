using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

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
    void LoseHealth()
    {
        
        health -= 1;
    }
    void resetInvulnerability()
    {
        invincible = false;
    }
}
