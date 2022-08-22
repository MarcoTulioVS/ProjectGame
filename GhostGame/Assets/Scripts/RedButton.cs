using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour {

	Animator anim;
	public GameObject blockMove; 

	void Start () {
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D col){

		if(col.gameObject.tag=="pedrinha"){

			anim.SetBool ("pressed",true);
			blockMove.SetActive (false);
			BoxBlocked.instance.countActiveButton++;
			//Arrancar porque não executa a animação de volta
			gameObject.GetComponent<Collider2D> ().enabled = false;

		}

	}

	void OnCollisionExit2D(Collision2D notCol){
	
		if (notCol.gameObject.tag == "pedrinha") {
		
			anim.SetBool ("pressed",false);
			BoxBlocked.instance.countActiveButton--;
			//Arrancar porque não executa a animação de volta
			gameObject.GetComponent<Collider2D> ().enabled = true;

			if (BoxBlocked.instance.countActiveButton < 0) {
			
				BoxBlocked.instance.countActiveButton = 0;
			
			}

		}
	}


}
