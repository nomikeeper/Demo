using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behavior : MonoBehaviour {

	public Transform p_pos;
	public float speed = 2f;
	public int timer;
	public float[,] sheetMap;
	//private variables
	private CircleCollider2D ccd;
	// Use this for initialization
	void Start () {
		ccd = GetComponent<CircleCollider2D> ();
		transform.position = calculatePos (p_pos);
	}
	
	// Update is called once per frame
	void Update(){
		if(Time.time > timer){
			transform.Translate (-Vector2.right * speed * Time.deltaTime);
			if(gameObject.transform.position.x < -9) {
				gameObject.SetActive (false);
			}			
		}

		Debug.Log (Time.time);
	}
	// fixedUpdate is calling a frame in fixed time
	void fixedUpdate () {
	}

	void spawner(){
	}

	Vector3 calculatePos(Transform pos){
		float a = pos.position.x;
		a = a + (ccd.radius / 2)* 0.75f + (speed * 5);
		return new Vector3 (a, 0, 0);
	}

	/*float getPosition(){
		float position;
		return position;
	}*/
}
