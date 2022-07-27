using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour {

	Animator anim;
	public List<Transform> listPoints;
	int posNumber;
	bool isRunning;

	void Start () {

		isRunning = true;
		anim = GetComponent<Animator> ();
		StartCoroutine ("PlayScare");

	}
	

	void Update () {
		
	}

	IEnumerator PlayScare(){

		while (true) {

			int number = Random.Range (2, 4);
			anim.SetInteger ("transition", number);

			if (number == 3) {

				yield return new WaitForSeconds (0.6f);
			
			} else {
				
				yield return new WaitForSeconds (2);
			}
			posNumber = Random.Range (0, 6); 

			if (posNumber >= 3) {
			
				transform.eulerAngles = new Vector2 (0, 0);
				int leftSide = Random.Range (0, 3);
				transform.position = listPoints [leftSide].position;

			} else if(posNumber<3) {
			
				transform.eulerAngles = new Vector2 (0, 180);
				int rightSide = Random.Range (3,6);
				transform.position = listPoints [rightSide].position;
			}
		}

	}
		
}
