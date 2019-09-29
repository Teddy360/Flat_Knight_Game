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
	
    void onTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Debug.Log("NExtScene");
            SceneManager.LoadScene(nextSceneToLoad);
            Debug.Log("NextSCene");
        }
            
        
    }
   public void nextScene()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
