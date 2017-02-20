using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move_player : MonoBehaviour {

	//public variables
	public GameObject player;

	// private variables
	player_control pc;
	Slider slid;
	// Use this for initialization
	void Start () {
		pc = player.gameObject.GetComponent<player_control> ();
		slid = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// FixedUpdate function for object has some physics
	void FixedUpdate(){
		pc.setPosition (slid.value);
	}
}
