using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogMonster : MonoBehaviour {

	public GameObject dialogMonsterPanel;
	int indexDialog;

	public List<string> dialogMonsterList;

	bool endDialogMonster;

	public Text monsterDialogText;

	public static DialogMonster instance;

	public bool activeMonsterDialog;

	void Awake(){

		instance = this;
	
	}
	void Start () {
		
	}
	

	void Update () {
		ChangeDialogJoystick ();
	}

	public void NextDialog(){

		indexDialog++;

		if (indexDialog > dialogMonsterList.Count - 1) {

			indexDialog = dialogMonsterList.Count - 1;
			dialogMonsterPanel.SetActive (false);
			endDialogMonster = true;
			activeMonsterDialog = false;
			GameController.instance.dialogGhostPanel.SetActive (true);
		}


		monsterDialogText.text = dialogMonsterList [indexDialog];

	}

	void ChangeDialogJoystick(){

		if (Input.GetButtonDown("Jump") && !endDialogMonster) {

			NextDialog ();

		}

	}
}
