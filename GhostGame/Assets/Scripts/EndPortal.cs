using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortal : MonoBehaviour {

	public GameObject player;


	void Start () {
		
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.layer == 8) {

			//Disabilita colisão e fisica
			col.GetComponent<Collider2D> ().enabled = false;
			col.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;

			//Quando o portal colidi com algum inimigo, o player(fantasma) sai de dentro do objeto
			//Logo em seguida o objeto é destruido
			Enemies.instance.getOutBodyWhenColliderWithPortal (player);
			Destroy (col.gameObject, 2f);


			SoundController.instance.PlaySound (SoundController.instance.sfxFinalPortal);
			//Verifica se a variavel countEnemies do GameController é igual ao valor da variavel quantMaxEnemies
			//Caso seja vai pra próxima fase
			StartCoroutine("NextLevel");

		}

	}

	IEnumerator NextLevel(){
	
		yield return new WaitForSeconds (3);
		GameController.instance.GoToNextScene();

	}
}
