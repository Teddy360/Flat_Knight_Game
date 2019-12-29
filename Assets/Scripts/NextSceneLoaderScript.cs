using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoaderScript : MonoBehaviour {

   int nextSceneToLoad;
    
	
	void Start ()
    {

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
	}
	
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Ontriggerenter");
        if(col.tag == "Player")
        {
            Debug.Log("NextScene");
         
            SceneManager.LoadScene(nextSceneToLoad);
            Debug.Log("NextSCene");
        }
            
        
    }
   public void nextScene()
    {
        Debug.Log("NextScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
