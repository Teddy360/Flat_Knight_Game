using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public bool isDeadEnemy = false;
    public GameObject Heart;
    void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.tag == "Blade")
        {
           
            Debug.Log("ABOUT TO CREATE HEART AT");
           
            isDeadEnemy = true;
          


        }

    }
    public void onDeath()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        Instantiate(Heart, new Vector3(x, y, 0), Quaternion.identity);
        Debug.Log("Before destory");
        Destroy(this.gameObject);
    }
}