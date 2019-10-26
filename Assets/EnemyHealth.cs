using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public bool isDeadEnemy = false;
   
    public GameObject Heart;
    private GameObject instantiatedObj;
    
    void Start()
    {
       
    }
    
    public void onDeath()
    {

        if(isDeadEnemy != true)
        {
            float x = this.transform.position.x;
            float y = this.transform.position.y;

            if(Heart != null)
            {
                Instantiate(Heart, new Vector3(x, y, 0), Quaternion.identity);
            }

        
            isDeadEnemy = true;
            Destroy(this.gameObject);
        }
 
            
    }
    void Update()
    {

    }
}