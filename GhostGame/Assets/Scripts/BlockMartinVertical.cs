using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMartinVertical : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
	
		if (col.gameObject.layer == 9) {
		
			gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
		
		}
	
	
	}
}
