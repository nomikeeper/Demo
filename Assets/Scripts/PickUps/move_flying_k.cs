using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_flying_k : MonoBehaviour {


	//private variables
	private float flying_Speed = 3.8f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-Vector2.right * flying_Speed * Time.deltaTime);
		if (gameObject.transform.position.x < -9.5) {
			Destroy (gameObject);
		}
	}

	public void SetFlyingSpeed(float newSpeed){
		flying_Speed = newSpeed;
	}
}
