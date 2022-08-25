using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour {

	public GameObject tutorial;
	public GameObject menuOptions;
	public Animator anim;

	public Image imageEnemy;
	public Text nameEnemyText;
	public Text descriptionEnemy;

	public List<string> listNameEnemies;
	public List<Sprite> listImagesEnemies;
	public List<string>listDescriptionEnemies;

	int indexNames;
	int maxCountNames;

	int maxCountDescription;
	int minCountDescription;
	int indexDescription;
	int indexImage;

	void Start () {
		maxCountNames = listNameEnemies.Count;
	}
	

	void Update () {

		SetNameEnemy ();
		SetDescriptionEnemy ();

	}

	public void StartGame(){
	
		SceneManager.LoadScene ("opening_1");
	
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


	void SetNameEnemy(){

		nameEnemyText.text = listNameEnemies [indexNames]; 
	}


	void SetDescriptionEnemy(){

		defineMaxMinCountDescription ();

		if (indexDescription <= minCountDescription) {

			indexDescription = minCountDescription;
			descriptionEnemy.text = listDescriptionEnemies [indexDescription];


		} else if(indexDescription>=minCountDescription) {

			indexDescription = maxCountDescription;
			descriptionEnemy.text = listDescriptionEnemies [indexDescription];
		}

		imageEnemy.sprite = listImagesEnemies [indexImage];

	}

	void defineMaxMinCountDescription(){

		switch (nameEnemyText.text) {

		case "SALIVA":

			maxCountDescription = 1;
			minCountDescription = 0;
			indexImage = 0;
			break;
		case "COLORADO":
			maxCountDescription = 3;
			minCountDescription = 2;
			indexImage = 1;
			break;
		case "GOSMA":
			maxCountDescription = 5;
			minCountDescription = 4;
			indexImage = 2;
			break;
		case "MARTIN":
			maxCountDescription = 7;
			minCountDescription = 6;
			indexImage = 3;
			break;
		case "MEDUSA":
			maxCountDescription = 9;
			minCountDescription = 8;
			indexImage = 4;
			break;
		case "PEDRADA":
			maxCountDescription = 11;
			minCountDescription = 10;
			indexImage = 5;
			break;
		case "PEDRINHA":
			maxCountDescription = 13;
			minCountDescription = 12;
			indexImage = 6;
			break;
		case "PULINHO":
			maxCountDescription = 15;
			minCountDescription = 14;
			indexImage = 7;
			break;
		case "RATO":
			maxCountDescription = 17;
			minCountDescription = 16;
			indexImage = 8;
			break;
		case "GATO":
			maxCountDescription = 19;
			minCountDescription = 18;
			indexImage = 9;
			break;
		case "CACHORRO":
			maxCountDescription = 21;
			minCountDescription = 20;
			indexImage = 10;
			break;
		default:
			break;

		}
	}

	public void NextName(){

		indexNames++;

		if (indexNames > maxCountNames - 1) {

			indexNames = maxCountNames - 1;


		}

	}

	public void PreviousName(){

		indexNames--;

		if (indexNames < 0) {

			indexNames = 0;


		}

	}

	public void NextDescription(){

		indexDescription++;

		if (indexDescription > maxCountDescription) {

			indexDescription = maxCountDescription;

		}


	}

	public void PreviousDescription(){

		indexDescription--;

		if (indexDescription < minCountDescription) {

			indexDescription = minCountDescription;

		}


	}

	public void CallTutorialScene(){

		SceneManager.LoadScene (2);

	}

}
