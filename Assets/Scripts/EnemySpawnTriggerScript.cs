using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTriggerScript : MonoBehaviour
{

    public GameObject Enemy;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Vector3 spawnPos = new Vector3(this.transform.position.x, this.transform.position.y - 5, this.transform.position.z);
            Instantiate(Enemy, spawnPos, Quaternion.identity);
            Destroy(this);
        }
    }



}
