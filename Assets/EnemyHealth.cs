using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public bool isDeadEnemy = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            isDeadEnemy = true;
          


        }
    }
}