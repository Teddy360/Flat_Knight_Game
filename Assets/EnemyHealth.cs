using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public bool isDeadEnemy = false;
    public GameObject Heart;
    private GameObject instantiatedObj;
    

    void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.tag == "Blade")
        {
           
            Debug.Log("ABOUT TO CREATE HEART AT");
            Debug.Log("hit");
            isDeadEnemy = true;
          


        }

    }
    public void onDeath()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        Debug.Log("Before destory");
        Instantiate(Heart, new Vector3(x, y, 0), Quaternion.identity);
        
        Destroy(this.gameObject);
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Health").Length > 1)
        {
            float x = this.transform.position.x;
            float y = this.transform.position.y;
            instantiatedObj = (GameObject)Instantiate(Heart, new Vector3(x, y, 0), Quaternion.identity);
            Destroy(instantiatedObj);
        }

    }
}