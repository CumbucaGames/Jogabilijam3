using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateObject : MonoBehaviour {

	Rigidbody2D rb;

	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		rb.AddForce(transform.forward * 10.0f);
	}
}
