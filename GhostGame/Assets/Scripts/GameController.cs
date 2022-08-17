﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public int quantMaxEnemies;
	public int countEnemies;

	[SerializeField]
	int enemiesInScene;

	public float quantEnergy;
	public Image imageBar;
	public Image imageMoldureBar;

	public float quantLife;
	public Image imageLifeBar;
	public Image imageMoldureLifeBar;

	public Transform trPlayer;

	public GameObject panelGameOver;
	public GameObject pauseMenu;
	public GameObject menuPause;

	public Text textMsg;
	public Text buttonMsg;

	public Text ghostDialogText;
	public GameObject dialogGhostPanel;

	public List<string>dialogGhostList;

	int indexDialog;

	public bool dialogOn;

	public Transform trCheckPoint;

	public bool checkPoint;

	public Text msgCheckpoint;

	public Image imgSpecialSkill;

	void Awake(){

		instance = this;

	}
	void Start () {

		ghostDialogText.text = dialogGhostList [indexDialog];
		//StartCoroutine ("DialogGhost");

		if (dialogOn) {
			Player.instance.speed = 0;
		}
	}
	

	void Update () {
		imageBar.fillAmount = quantEnergy / 100;
		imageLifeBar.fillAmount = quantLife / 100;

		GetCameraBackToPlayer ();

		StartCoroutine ("DelayChangeDialogJoystick");

		if (enemiesInScene > 0) {
			ShowSpecialSkill ();
		}

	}

	public void GoToNextScene(){

		countEnemies++;


		if (countEnemies == quantMaxEnemies) {
			
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		
		}

	}

	public void CallScene(int i){

		//CASO OCORRA ALGUM PROBLEMA RETIRAR
		GameObject g = GameObject.FindGameObjectWithTag ("Player");
		Destroy (g);
		SceneManager.LoadScene (i);
	}

	void GetCameraBackToPlayer(){
	
		if (CameraScript.instance.tr == null) {
		
			CameraScript.instance.tr = trPlayer;
		
		}
	
	}

	public void DecrementLife(){

		float halfLife = quantLife / 2;

		if (halfLife < 25) {
			
			quantLife = 0;
			GameOver ();
		} else {
				
			quantLife -= halfLife;

		}

	}


	public void GameOver(){

		panelGameOver.SetActive (true);
		textMsg.text = CreateTextTitle ();
		buttonMsg.text = CreateTextButton ();

	}

	public void RestarGame(){

		//Colocar checkPoint caso tenha pegado
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}

	private string CreateTextTitle(){
	
		int number = Random.Range (1, 6);
	
		switch (number) {
	
			case 1:
				return "Acabou pra você meu chapa!!!";
			case 2:
				return "Não deu não!";
			case 3:
				return "Já foi tarde";
			case 4:
				return "Que pena. Ha! Ha!";
			case 5:
				return "Quem sabe da próxima! He He!";
			default:
				return "nada";
		}
	}

	private string CreateTextButton(){

		int number = Random.Range (1, 6);

		switch (number) {

			case 1:
				return "Bora mais uma";
			case 2:
				return "Que não vai dar o que";
			case 3:
				return "E cá vamos nós de novo";
			case 4:
				return "Agora vou jogar sério";
			case 5:
				return "Essa não valeu";
			default:
				return "nada";
		}
	}


	public void HidePause(){

		pauseMenu.SetActive (false);


	}

	public void ShowPause(){
	
		pauseMenu.SetActive (true);
	
	}

	public void ShowMenuPause(){

		menuPause.SetActive (true);

	}

	public void HideMenuPause(){
	
		menuPause.SetActive (false);
	
	}

	public void QuitGame(){

		Application.Quit ();

	}

//	IEnumerator DialogGhost(){
//
//		for (int i = 0; i <= dialogGhostList.Count -1; i++) {
//
//			ghostDialogText.text = dialogGhostList [i];
//			yield return new WaitForSeconds (5);
//		
//		}
//
//		dialogGhostPanel.SetActive (false);
//
//	}

	public void NextDialog(){

		indexDialog++;

		if (indexDialog > dialogGhostList.Count - 1) {
		
			indexDialog = dialogGhostList.Count - 1;
			dialogGhostPanel.SetActive (false);
			Player.instance.speed = 8;
		}
		ghostDialogText.text = dialogGhostList [indexDialog];

	}

	public string GetActualScene(){
	
		return SceneManager.GetActiveScene ().name;
	
	}

	IEnumerator DelayChangeDialogJoystick(){
	

		if (Input.GetKeyDown (KeyCode.JoystickButton1)) {

			NextDialog ();
			
		}
		yield return new WaitForSeconds (1);
	
	}

	public void CheckPoint(Transform tr){
		
		tr.position = trCheckPoint.position;

	}

	public void ShowSpecialSkill(){

		if (Enemies.instance.specialSkill) {
		
			imgSpecialSkill.enabled = true;
		
		} else {
		
			imgSpecialSkill.enabled = false;
		}

	}


		
}
