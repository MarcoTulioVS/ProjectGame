using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	void Start () {
		

	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
	
		if (col.gameObject.layer == 8) {
			
			FallPlataformCollider.instance.colliderOn = true;
				
		}
	
	}
}
