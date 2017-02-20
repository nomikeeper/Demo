using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ChangeScenes(string Destination){
		switch (Destination) {
		case "Play":
			SceneManager.LoadScene (1);
			break;
		case "Score Scene":
			PlayerPrefs.SetString ("Selection", "Score Scene");
			SceneManager.LoadScene (0);
			break;
		case "Song List":
			PlayerPrefs.SetString ("Selection", "Song List");
			SceneManager.LoadScene (0);
			break;
		case "Main menu":
			PlayerPrefs.SetString ("Selection", "Main Menu");
			SceneManager.LoadScene (0);
			break;;
		case "Options":
			SceneManager.LoadScene (0);
			PlayerPrefs.SetString ("Selection", "Options");
			break;
		}
	}
}
