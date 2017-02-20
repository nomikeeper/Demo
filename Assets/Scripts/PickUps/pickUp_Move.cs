using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp_Move : MonoBehaviour {

	public AudioClip audioCp;
	//private variables
	private float flying_Speed = 1.0f;
	private float volScale = 1.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-Vector2.right * flying_Speed * Time.deltaTime);
		if (gameObject.transform.position.x < -9) {
			gameObject.SetActive (false);
		}
	}

	public void SetFlyingSpeed(float newSpeed){
		flying_Speed = newSpeed;
	}

	public void playTheSound(Vector3 position){
	}
}
