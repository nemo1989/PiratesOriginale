﻿using UnityEngine;
using System.Collections;

public class DestroyObjects : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collide)
	{
		if (collide.gameObject.tag == "Obst")
			Destroy (collide.gameObject);
				
	}
}
