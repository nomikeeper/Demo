using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songInfo : MonoBehaviour {

	public string songName;

	//private Variables
	private int HighScore;
	// Use this for initialization
	void Start () {
		HighScore = PlayerPrefs.GetInt ("HighScore", 0);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string getName(){
		return songName;
	}

	public void highScoreChecker(int score){
		if (score > HighScore) {
			HighScore = score;
			PlayerPrefs.SetInt ("HighScore", HighScore);
		}
	}
	public string getHighScore(){
		string text = "Best : " + HighScore;
		return text;
	}
}
