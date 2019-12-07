using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public bool isDeadEnemy = false;
   
    public GameObject Heart;
    private GameObject instantiatedObj;
    public GameObject effect;
    public GameObject bloodSplash;
    
    void Start()
    {
       
    }
    
    public void onDeath()
    {

        if(isDeadEnemy != true)
        {
            float x = this.transform.position.x;
            float y = this.transform.position.y;
           
            if (Heart != null)
            {
                Instantiate(Heart, new Vector3(x, y, 0), Quaternion.identity);
                
            }

        
            isDeadEnemy = true;
            Instantiate(effect, transform.position, Quaternion.identity);
           
            if(bloodSplash != null)
            {
                Instantiate(bloodSplash, transform.position, Quaternion.identity);
            }
                
            Destroy(this.gameObject);
        }
 
            
    }
    void Update()
    {

    }
}