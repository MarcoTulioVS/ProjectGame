using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb;

	[SerializeField]
	private float speed;
	Vector3 movement;
	public bool activeObject;
	public string nameObject;

	public static Player instance;

	public GameObject player;

	public Transform pointCollider;
	public float radius;
	public LayerMask enemyLayer;

	public Animator anim;
	bool isScaring;

	void Awake(){
	
		instance = this;
	
	}



	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();	
	}
	

	void Update () {
		
	}

	void FixedUpdate(){

		Move ();
		Scare ();

	}

	void Move(){

		float moveX = Input.GetAxis ("Horizontal");

		if (moveX == 0 && !isScaring) {
			
			anim.SetInteger ("transition", 0);
		}

		if ((moveX > 0 || moveX<0) && !isScaring ) {
			
			anim.SetInteger ("transition", 1);
		}

		float moveY = Input.GetAxis ("Vertical");

		movement = new Vector3 (moveX, moveY, 0);

		rb.velocity = movement * speed;

	}

	void Scare(){

		if (Input.GetButtonDown ("Fire1")) {

			isScaring = true;
			anim.SetInteger ("transition", 2);
			Collider2D hit = Physics2D.OverlapCircle (pointCollider.position, radius,enemyLayer);

			if (hit != null) {
			
				Debug.Log ("Acertou");
			
			}

			StartCoroutine ("resetScare");
		}


	}

	void OnDrawGizmos(){

		Gizmos.DrawWireSphere (pointCollider.position, radius);

	}

	void OnTriggerEnter2D(Collider2D col){

		//Layer 8 = enemies
		//Ao colidir com o inimigo o fantasma o possui
		if (col.gameObject.layer == 8) {

			activeObject = true;
			nameObject = col.name;
			player.SetActive (false);
		
		}

	}

	IEnumerator resetScare(){
	
		yield return new WaitForSeconds (0.583f);
		isScaring = false;
	
	}


}
