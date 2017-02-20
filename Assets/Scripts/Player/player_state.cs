using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_state : MonoBehaviour {

	public GameManager gm;
	//private variables
	private bool playerState;
	//private composerController comCont;
	// Use this for initialization

	void Awake(){
		playerState = true;
	}
	void Start () {
		//comCont = GetComponentInChildren<composerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		float y = gameObject.transform.position.y;
		if (y < -5.0f) {
			playerState = false;
		}

		CheckPlayerState (playerState);
	}

	public bool isAlive(){
		return playerState;
	}
	//checking the player state if player is alive or not
	void CheckPlayerState(bool state){
		if (!state) {
			Debug.Log ("Player is dead. It`s game over");
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("Dodge")) {
			playerState = false;
		} else if (coll.gameObject.CompareTag ("PickUp")) {
			pickUp_Move pum = coll.gameObject.GetComponent<pickUp_Move> ();
			//comCont.celebrate ();
			//pum.audioCp
			AudioSource.PlayClipAtPoint (coll.gameObject.GetComponent<AudioSource> ().clip, coll.transform.position);
			gm.pointInc ();
			Destroy (coll.gameObject);
		} else if (coll.gameObject.CompareTag ("1")) {
			Destroy (coll.gameObject);
		}
	}
}
