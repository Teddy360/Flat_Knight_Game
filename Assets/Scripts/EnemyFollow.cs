using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

  
    public float speed;
    public float distance;
    private Transform target;
	// Use this for initialization
	void Start ()
    {
        Debug.Log("findingtarget");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Debug.Log(target);
	}


   
    // Update is called once per frame
    void Update ()
    {
        if (Mathf.Abs(this.transform.position.x - target.position.x) <= distance)
        {
            Debug.Log("Goingtoplayer");
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
       
	}
}
