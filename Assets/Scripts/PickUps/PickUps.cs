using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PickUps : MonoBehaviour {

	//public GameObject[] pickUps;
	public float[] timeTable;
	public GameObject[] NoteTable;
	//private variables
	bool start =false;
	float speed = 3.8f;
	float StopWatch = -5f;
	int k = 0;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (start){
			StopWatch += Time.deltaTime;
			check (StopWatch);
		}
		
	}

	//Setting the bool for should we start the timer or not.. Timer Starts when player hits the button
	public void StartTheTimer(){
		start = true;
	}
	//public function for giving the speed of the flying object
	public float GetSpeed(){
		return speed;
	}

	public float getTimer(){
		return StopWatch;
	}

	//Checking if it's time for to generate the note
	void check(float time){
		if (k < timeTable.Length) {
			if (timeTable [k] < (time + 5f) && (time + 5f) < timeTable [k] + 0.1f) {
				spawnNote (k);
				k++;
			}
		}
	}


	//Fuction for note Spawning.
	void spawnNote(int i){
		float temp = player.gameObject.transform.position.x + (5f * speed);
		Instantiate (NoteTable [i], new Vector2 (temp, NoteTable [i].transform.position.y), Quaternion.identity);
	}
}
