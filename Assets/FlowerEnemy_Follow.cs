using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerEnemy_Follow : MonoBehaviour
{
    private Transform target;
    public float speed;
    public float distance;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {



        if (Mathf.Abs(this.transform.position.x - target.position.x) <= distance)
        {
            Debug.Log("Goingtoplayer");
            //transform.position = 
            Vector2 newPosition = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
}