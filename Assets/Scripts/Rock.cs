﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
    {
        Destroy(this.gameObject);
    }
}
