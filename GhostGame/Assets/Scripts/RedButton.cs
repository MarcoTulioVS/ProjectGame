using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour {

	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D col){

		if(col.gameObject.tag=="pedrinha"){

			anim.SetBool ("pressed",true);

		}

	}

	void OnCollisionExit2D(Collision2D notCol){
	
		if (notCol.gameObject.tag == "pedrinha") {
		
			anim.SetBool ("pressed",false);
		
		}
	}
}
