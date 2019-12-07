using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Stage_One: MonoBehaviour
{
    private Transform target;
    public float speed;
    public float distance;
    public AudioSource FloorHit;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Wall_Two").GetComponent<Transform>();
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
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Wall_Two")
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            target = GameObject.FindGameObjectWithTag("Wall_One").GetComponent<Transform>();
        }
        if (col.tag == "Wall_One")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            target = GameObject.FindGameObjectWithTag("Wall_Two").GetComponent<Transform>();
        }
        if(col.tag == "Floor")
        {
            FloorHit.Play();
        }
    }
}