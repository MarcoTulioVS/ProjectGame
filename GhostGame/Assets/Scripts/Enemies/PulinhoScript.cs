using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulinhoScript : Enemies {

	Rigidbody2D rb;
	public float speed;
	public float jumpForce;
	Animator anim;
	public GameObject spark;

	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		jump (rb, jumpForce, anim);

	}

	void FixedUpdate(){

		MainController (gameObject.name, rb, speed,anim);

	}



	IEnumerator blinkSpark(){

		spark.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		spark.SetActive (false);

	}

	//Tentar mudar isso. Nao pode ficar aqui porque senao todos os scripts de inimigo terão que sobreescrever o metodo
	//Talvez encaixar isso no Enemies
	protected override void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
		
			StartCoroutine ("blinkSpark");
		
		}
	}
		
}
