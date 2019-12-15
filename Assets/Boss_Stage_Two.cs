using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Stage_Two : MonoBehaviour {
    public GameObject Flower;
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnFlowers", 2.0f, 5.0f);
	}
	
	void SpawnFlowers()
    {
        Vector3 position = new Vector3(Random.Range(-.5f, 15f), 0, Random.Range(-.5f, 15f));
        Instantiate(Flower, position, Quaternion.identity);
    }
}
