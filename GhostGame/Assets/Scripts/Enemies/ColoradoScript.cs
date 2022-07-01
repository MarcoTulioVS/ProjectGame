using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoradoScript : Enemies {

	Rigidbody2D rb;
	public float speed;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		
	}

	void FixedUpdate(){

		if (Player.instance.activeObject && Player.instance.nameObject == "colorado") {
		
			moveControl (rb,speed);
		}

	}
}
