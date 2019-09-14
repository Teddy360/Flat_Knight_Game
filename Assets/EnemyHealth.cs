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
            float x = this.transform.position.x;
            float y = this.transform.position.y;
            Debug.Log("ABOUT TO CREATE HEART AT");
            Instantiate(Heart, new Vector3(x, y, 0), Quaternion.identity);
            isDeadEnemy = true;
          


        }
    }
}