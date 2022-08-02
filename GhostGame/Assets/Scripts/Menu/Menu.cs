using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject tutorial;
	public GameObject menuOptions;

	void Start () {
		
	}
	

	void Update () {
		
	}

	public void StartGame(){
	
		SceneManager.LoadScene ("scene1");
	
	}

	public void ExitGame(){
		
		Application.Quit ();
	
	}

	public void ShowTutorial(){

		tutorial.SetActive (true);
		menuOptions.SetActive (false);

	}

	public void HideTutorial(){
	
		tutorial.SetActive (false);
		menuOptions.SetActive (true);
	}
}
