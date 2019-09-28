using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public GameObject Player;
    public float speed;
    public float distance;
    private Transform target;
	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
   
    // Update is called once per frame
    void Update ()
    {
        
        if (Mathf.Abs(this.transform.position.x - Player.transform.position.x) <= distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
       
	}
}
