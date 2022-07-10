using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

	public bool insideBody;
	public static Enemies instance;
	private bool collPortalRed;
	private bool collPortalRed1;
	private bool collPortalGreen;
	private bool collPortalGreen1;
	public bool isJumping;
	protected bool doubleJump;
	private float movement;
	protected bool activeSpark;
	protected bool withBomb;
	public float speed;
	public bool inFormGosma;

	[SerializeField]
	private GameObject shine;

	public bool colWall;

	protected bool isGround; 
	protected bool notColWall;
	void Awake(){
	
		instance = this;
	}
	void Start () {
		
	}
	

	void Update () {
		
	}
		

	protected virtual void moveControl(Rigidbody2D rb){

		movement = Input.GetAxis ("Horizontal");

		if (movement > 0) {
		
			transform.eulerAngles = new Vector2 (0, 0);

		} else if(movement<0) {
		
			transform.eulerAngles = new Vector2 (0, 180);
		}

		rb.velocity = new Vector2 (speed * movement, rb.velocity.y);
	
	}

	protected virtual void moveControl(Rigidbody2D rb,Animator anim){

		movement = Input.GetAxis ("Horizontal");

		if (movement > 0) {

			transform.eulerAngles = new Vector2 (0, 0);
		
		} else if (movement < 0) {
		
			transform.eulerAngles = new Vector2 (0, 180);
		
		}

		if (movement > 0 && !isJumping && !inFormGosma) {

			transform.eulerAngles = new Vector2 (0, 0);
			anim.SetInteger ("transition",1);

		} else if (movement < 0 && !isJumping && !inFormGosma) {

			transform.eulerAngles = new Vector2 (0, 180);
			anim.SetInteger ("transition",1);

		} else if(movement==0 && !isJumping && !inFormGosma) {
		
			anim.SetInteger ("transition", 0);
		}

		rb.velocity = new Vector2 (speed * movement, rb.velocity.y);

	}


	protected void MainController(string nameObject,Rigidbody2D rb){

		if (Player.instance.activeObject && Player.instance.nameObject == nameObject) {

			moveControl (rb);
		}

	}

	protected void MainController(string nameObject,Rigidbody2D rb,Animator anim){

		if (Player.instance.activeObject && Player.instance.nameObject == nameObject) {

			moveControl (rb,anim);
		}

	}

	public void getOutBody(GameObject player){
	
		if(Input.GetKeyDown(KeyCode.Mouse1) && insideBody){

			player.SetActive (true);
			Player.instance.activeObject = false;
			insideBody = false;

		}
	
	}

	public void getOutBodyWhenColliderWithPortal(GameObject player){

		player.SetActive (true);
		Player.instance.activeObject = false;
		insideBody = false;

	}

	protected virtual void jump(Rigidbody2D rb,float jumpForce){

		if (Input.GetButtonDown ("Jump") && !isJumping && insideBody) {
			
			rb.AddForce (new Vector2 (0, jumpForce),ForceMode2D.Impulse);
			isJumping = true;
		
		}
	
	}

	protected virtual void jump(Rigidbody2D rb,float jumpForce,Animator anim){

		if (Input.GetButtonDown ("Jump") && !isJumping && insideBody) {

			anim.SetInteger("transition",2);
			rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			isJumping = true;
		
		} 
		
	
	}


	protected virtual void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "red") {

			collPortalRed= true;
		
		}

		if (col.gameObject.tag == "red1") {
		
			collPortalRed1 = true;
		
		}

		if (col.gameObject.tag == "green") {

			collPortalGreen= true;

		}

		if (col.gameObject.tag == "green1") {

			collPortalGreen1 = true;

		}

		if (col.gameObject.tag == "Player") {
		
			StartCoroutine ("blinkShine");

		}

		if (col.gameObject.tag == "bombItem" && gameObject.name == "saliva") {

			withBomb = true;
			Destroy (col.gameObject);

		}

		if (col.gameObject.tag == "areaGosma" && gameObject.name=="gosma") {
		
			//teste
			colWall = true;
			notColWall = false;

		}
			
	}

	void OnTriggerExit2D(Collider2D notCol){
	
		if (notCol.gameObject.tag == "areaGosma" && gameObject.name=="gosma") {
		
			colWall = false;
			notColWall = true;

		}
	
	}

	protected virtual void OnCollisionEnter2D(Collision2D col){
	
		if (col.gameObject.layer == 9) {
		
			isJumping = false;
			isGround = true;
		}
	
	}

	protected virtual void OnCollisionExit2D(Collision2D notCol){

		if (notCol.gameObject.layer == 9) {

			isGround = false;

		}


	}


	public void OnCollisionPortal(Transform tr,Transform portalRef){
	
		if (collPortalRed) {
			
			GameObject otherPortal = GameObject.FindGameObjectWithTag ("red1");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalRed = false;
			}
		}

		if (collPortalGreen) {

			GameObject otherPortal = GameObject.FindGameObjectWithTag ("green1");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalGreen = false;
			}
		}
	
	
	}

	public void OnCollisionPortal1(Transform tr,Transform portalRef){

		if (collPortalRed1) {

			GameObject otherPortal = GameObject.FindGameObjectWithTag ("red");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalRed1 = false;
			}
		}

		if (collPortalGreen1) {

			GameObject otherPortal = GameObject.FindGameObjectWithTag ("green");

			if (otherPortal != null) {

				tr.position = portalRef.position;
				collPortalGreen1 = false;
			}
		}


	}

	protected void showAnimation(Animator anim,string name){

		if (movement > 0) {
		
			anim.SetBool (name, true);

		} else if (movement < 0) {
		
			anim.SetBool (name, true);
		
		} else {
		
			anim.SetBool (name, false);
		}


	}

	IEnumerator blinkShine(){
	
		shine.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		shine.SetActive (false);
	
	}




}
