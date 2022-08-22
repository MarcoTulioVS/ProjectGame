using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour {

	Animator anim;
	public GameObject blockMove; 
	bool active;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D col){

		if(col.gameObject.tag=="pedrinha"){

			anim.SetBool ("pressed",true);
			blockMove.SetActive (false);
		
			if (!active) {
				
				BoxBlocked.instance.countActiveButton++;
				active = true;
			}

		}

	}

	void OnCollisionExit2D(Collision2D notCol){
	
		if (notCol.gameObject.tag == "pedrinha") {

			active = false;
			anim.SetBool ("pressed",false);
			BoxBlocked.instance.countActiveButton--;

			if (BoxBlocked.instance.countActiveButton < 0) {
			
				BoxBlocked.instance.countActiveButton = 0;
			
			}

		}
	}




}
