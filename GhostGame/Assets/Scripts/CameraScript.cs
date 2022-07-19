using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public float minX;
	public float minY;
	public float maxX;
	public float maxY;

	public Transform tr;

	public static CameraScript instance;

	void Start () {
		instance = this;
		//Debug.Log(GameObject.Find (Enemies.instance.gameObject.name));
	}
	

	void Update () {
		
		transform.position = new Vector3 (Mathf.Clamp (tr.position.x, minX, maxX), Mathf.Clamp (tr.position.y, minY, maxY),gameObject.transform.position.z);
	}
}
