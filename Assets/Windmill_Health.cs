using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Windmill_Health : MonoBehaviour
{
    public float invincibilityTime = 10000f;
    private bool invincible = false;
    public int health;
    public GameObject Next_Phase;
    public AudioSource hit_sound;
    public GameObject bossspawn;
    int next_Scene_To_Load;

    // Use this for initialization
    void Start()
    {
        print("pre-nextscene debug");
        next_Scene_To_Load = SceneManager.GetActiveScene().buildIndex + 1;
        print("post-nextscene debug");
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
    void OnDeath()
    {
   
        if (Next_Phase == null)
        {
            SceneManager.LoadScene(next_Scene_To_Load);
            Destroy(this.gameObject);
        }
        else
        {
            Instantiate(Next_Phase, bossspawn.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        

    }
    void resetInvulnerability()
    {
        invincible = false;
    }
}
