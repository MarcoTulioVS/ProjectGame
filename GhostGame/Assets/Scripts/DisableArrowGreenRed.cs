using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableArrowGreenRed : MonoBehaviour {

	public GameObject arrowGreen;
	public GameObject arrowRed;

	public GameObject controllerOutMouse;
	public GameObject controllerOutJoystick;

	public GameObject tutoMoveMonster;
	public GameObject tutoMoveGhost;

	void Start () {
		
	}
	

	void Update () {
		StartCoroutine ("DisableArrowRed");
		ShowTutorialMove ();
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player" && GameController.instance.quantEnergy>0) {

			arrowGreen.SetActive (false);
			arrowRed.SetActive (true);
			controllerOutMouse.SetActive (true);
			controllerOutJoystick.SetActive (true);

		}

	}

	IEnumerator DisableArrowRed(){

		if (Enemies.instance.insideBody) {
		
			yield return new WaitForSeconds (5);
			arrowRed.SetActive (false);
			controllerOutMouse.SetActive (false);
			controllerOutJoystick.SetActive (false);

		
		}

	}

	void ShowTutorialMove(){

		if (Enemies.instance.insideBody) {

			tutoMoveGhost.SetActive (false);
			tutoMoveMonster.SetActive (true);

		} else {
		
			tutoMoveGhost.SetActive (true);
			tutoMoveMonster.SetActive (false);
		
		}


	}
}
