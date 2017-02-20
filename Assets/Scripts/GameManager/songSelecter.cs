using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class songSelecter : MonoBehaviour {

	public AudioClip[] songList;
	public GameObject[] songlist2;
	public AudioSource asc;
	public Text SongName;
	public Text sessionScore;
	public Text bestScore;
	//private variables
	GameObject song;
	int Score = 0;
	// Awake function runs when scenes launches
	void Awake(){
		if (SceneManager.GetActiveScene().buildIndex == 0) {
			Score = PlayerPrefs.GetInt("SessionScore");
			Debug.Log (Score);
		}
		song = setSongIndex (PlayerPrefs.GetInt ("songIndex"));
		if (SongName) {
			song.GetComponent<songInfo> ().highScoreChecker (Score);
			SongName.text = song.GetComponent<songInfo> ().getName ();
			sessionScore.text = Score.ToString (); 
			bestScore.text = song.GetComponent<songInfo> ().getHighScore ();
		}
		song = Instantiate (song, new Vector2 (0, 0), Quaternion.identity) as GameObject;


	}
	// Use this for initialization
	void Start () {
		asc.clip = song.GetComponent<AudioSource>().clip;
		asc.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	}
	GameObject setSongIndex(int songIndex){
		if (songIndex == null) {
			return songlist2 [0];
		} else {
			return songlist2 [songIndex];
		}
	}

	public void selectSong(int songIndex){
		PlayerPrefs.SetInt ("songIndex", songIndex);
	}

	public PickUps getPickUpScript(){
		return song.GetComponent<PickUps> (); 
	}

}
