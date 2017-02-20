using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	//public variables
	public Animator mainMenu; 
	public Animator songList;
	public Animator scoreScene;

	//private variables
	Animator anim;
	string selection;
	void Awake(){
		selection = PlayerPrefs.GetString ("Selection");
		ShowUI (selection);
	}
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		setPosition (selection);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}

		if(Input.GetKeyDown("h")){
			anim.SetTrigger ("SongSelection");
		}
		if(Input.GetKeyDown("r")){
			anim.SetTrigger ("ResultPosition");
		}
		if(Input.GetKeyDown("i")){
			anim.SetTrigger ("idle");
		}
		if(Input.GetKeyDown("o")){
			anim.SetTrigger ("Options");
		}
	}

	//camera position setter
	public void setPosition(string selection){
		ShowUI (selection);
		switch (selection) {
		case "Score Scene":
			anim.SetTrigger ("ResultPosition");
			scoreScene.SetTrigger ("show");
			PlayerPrefs.SetString ("Selection", "idle");
			break;
		case "Main Menu":
			anim.SetTrigger ("idle");
			mainMenu.SetTrigger ("show");
			break;
		case "Song List":
			anim.SetTrigger ("SongSelection");
			songList.SetTrigger ("show");
			PlayerPrefs.SetString ("Selection", "idle");
			break;
		case "Options":
			anim.SetTrigger ("Options");
			PlayerPrefs.SetString ("Selection", "idle");
			break;
		}
	}


	void ShowUI(string selection){

		switch (selection) {
		case "Song List":
			mainMenu.SetTrigger ("close");
			mainMenu.SetTrigger ("idle");
			scoreScene.SetTrigger ("hide");
			break;
		case "Main Menu":
			songList.SetTrigger ("close");
			scoreScene.SetTrigger ("hide");
			break;
		case "Score Scene":
			songList.SetTrigger ("close");
			mainMenu.SetTrigger ("close");
			mainMenu.SetTrigger ("idle");
			break;
		}
	}

	void HideAllUI(){
		mainMenu.SetTrigger ("close");
		mainMenu.SetTrigger ("idle");
		songList.SetTrigger ("close");
	}
}
