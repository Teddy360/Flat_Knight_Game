using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTriggerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Instantiate(Enemy, new Vector3(Player.transform.position.x - 5, Player.transform.position.y, 0), Quaternion.identity);
            Destroy(this);
        }
    }



}
