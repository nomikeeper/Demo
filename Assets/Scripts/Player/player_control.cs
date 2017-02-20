using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour {

	//public variables
	public float shifting_Speed = 2.0f;
	public float floating_Y;

	//private variables
	float position_Y;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.25f,0,10));
	}
	
	// Update is called once per frame
	void Update () {

		//min and max of the position.y is ( -6, 6)
		/*Debug.Log (transform.position.y);
		floating_Y = Input.GetAxis ("Vertical");
		Vector2 move = new Vector2 (0, floating_Y);
		rb.position += (move * Time.deltaTime * shifting_Speed);*/
	}
	void FixedUpdate(){
		Vector2 move = new Vector2 (transform.position.x, getPosition ()); 
		rb.MovePosition (move);
	}

	float getPosition(){
		return position_Y;
	}
	public void setPosition(float temp){
		position_Y = temp;
	}
}
