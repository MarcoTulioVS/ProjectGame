using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlataformCollider : MonoBehaviour {

	public static FallPlataformCollider instance;

	public bool colliderOn;

	void Start () {
		instance = this;
	}
	

	void Update () {
		turnOnColliders ();
	}

	void turnOnColliders(){

		if (colliderOn) {
		
			gameObject.GetComponent<Collider2D> ().enabled = true;
			colliderOn = false;
		}

	}
}
