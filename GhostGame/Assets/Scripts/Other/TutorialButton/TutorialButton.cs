using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour {

	public Animator anim;

	void OnMouseOver(){

		anim.SetBool ("shaking",true);
	
	}

	void OnMouseExit(){
	
		anim.SetBool ("shaking", false);
	
	}

}
