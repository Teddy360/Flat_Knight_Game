using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerEnemy_Tunnel : MonoBehaviour {
    const float Y_SPEED = 4;
    public GameObject effect;
	void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Invoke("Popup", 1f);
    }
    void Popup()
    {
        this.transform.position += new Vector3(0, Y_SPEED, 0);
        StartCoroutine(UnderGround());
    }

    IEnumerator UnderGround()
    {
        yield return new WaitForSeconds(2);
        this.transform.position -= new Vector3(0, Y_SPEED, 0);
        Destroy(this);
    }
}
