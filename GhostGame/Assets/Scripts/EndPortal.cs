using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortal : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.layer == 8) {
		
			//Chamar a variavel que conta o numero de inimigos na cena e incrementa-la em 1
			//OBS: Essa variavel se encontra dentro do GameController
			Debug.Log("colidiu Inimigo");
		}

	}
}
