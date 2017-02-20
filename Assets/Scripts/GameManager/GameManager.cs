using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class GameManager : MonoBehaviour {

	public Text textRef;
	public player_state ps;
	public Animator startText;
	public Animator startPointer;
	public Animator GameHint;
	public KakashiGenerator ksg;
	public GameObject[] panelCtrls;
	public Animator sliderBtnAnim;
	public Animator countdownAnim;
	public Text countdownText;
	public Animator pause;
	public GameObject pausePanel;
	//private variables
	private bool isStarted;
	private bool isPaused;
	private int temp = 0;
	private Animator anim;
	private PickUps pickUpsScript;
	private songSelecter songSelectorScript;
	private panelController panelCtrl;
	private Text sessionPointRef;
	private Text highScoreRef;
	private AudioSource asc;
	private LevelHandler lh;
	private int point = 0;
	private int highScore = 0;
	private int sessionScore = 0;
	private Stopwatch timer = new Stopwatch();
	private float clipTimeCounter = 0;
	private bool wasPlaying = false;
	// when Scene is loaded 
	void Awake(){
	}
	// Use this for initialization. Set essential values of certain variables.
	void Start () {
		isStarted = false;
		isPaused = false;
		asc = GetComponent<AudioSource> ();
		lh = GetComponent<LevelHandler> ();
		songSelectorScript = GetComponent<songSelecter> ();
		pickUpsScript = songSelectorScript.getPickUpScript ();
	}
	
	// Update is called once per frame
	void Update () {
		if (asc.isPlaying) {
			clipTimeCounter += Time.deltaTime;
			wasPlaying = true;
		}
		if (!isStarted && pickUpsScript) {
			CountDownCheck (pickUpsScript.getTimer ());
			if (pickUpsScript.getTimer () >= -0.02f ){
				asc.Play (); // start playing background music
				isStarted = true;
			}
		}
		if (ps) { // checking a game object that contains ps is exist or not
			if (Input.GetKeyDown (KeyCode.Escape)) {
				pauseUnpause ();
			}
			pauseChecker ();
			if (ps.isAlive ()) { // checking the players state is it alive or dead
				textRef.text = point.ToString ();
				if (clipTimeCounter >= asc.clip.length - 0.2f && isStarted) {
					new WaitForSeconds (2);
					EndTheGame ();
				}
			} else {
				EndTheGame ();
			}
		} else {
			Time.timeScale = 1;
		}
		// when point changes check transfer the point value to the panel controller
		if (temp != point) {
			panelController (point);
			temp = point;
		}

	}


	public void pauseUnpause(){
		isPaused = !isPaused;
	}
	// Checking the game if it's paused or not
	void pauseChecker(){
		if (isPaused) {
			if (asc.isPlaying)
				asc.Pause();
			Time.timeScale = 0;
			pausePanel.SetActive (true);
		} else if (!isPaused && !wasPlaying) {
			Time.timeScale = 1;
			pausePanel.SetActive (false);
		}else if (!isPaused && wasPlaying) {
			Time.timeScale = 1;
			asc.UnPause();
			pausePanel.SetActive (false);
		}
	}
	// point counter
	public void pointInc(){
		point++; 
	}


	//game Starter run few functions essential to run the game.
	public void StartTheGame()
	{
		//Start Text pointer animation Trigger
		startPointer.SetBool ("isGameStarted", true);
		//Start Text animation Trigger
		startText.SetBool ("isGameStarted", true);
		GameHint.SetTrigger ("isGameStarted");
		sliderBtnAnim.SetBool ("isActive", true);
		pickUpsScript.StartTheTimer();

	}

	// behaviour of game over.
	public void EndTheGame(){
		PlayerPrefs.SetInt ("SessionScore", point); // saving session point to the memory
		lh.ChangeScenes ("Score Scene"); // Changing to game over screen
	}

	// panel icon controller
	void panelController(int point){
		if (point >= 1 && point < 3) {
			initChecker (ps, 0);
		} 
		else if (point >= 3 && point < 5) {
			initChecker (ps, 1);
		} 
		else if (point >= 5 && point < 7) {
			initChecker (ps, 2);
		} 
		else if (point >= 7 && point < 9) {
			initChecker (ps, 3);
		} 
		else if (point >= 9 && point < 11) {
			initChecker (ps, 4);
		} 
		else if (point >= 11 && point < 13) {
			initChecker (ps, 5);
		} 
		else if (point >= 13 && point < 15) {
			initChecker (ps, 6);
		} 
		else if (point >= 15 && point < 17) {
			initChecker (ps, 7);
		} 
		else if (point >= 17 ) {
			initChecker (ps, 8);
			}
		}

	// Checker for Icon initializing   ( which Icon should it initialize or swap )
	void initChecker(player_state ps, int i){
		if (ps && panelCtrls [i].GetComponent<Animator> ().GetBool ("intro") == false) {

			if (i == 3 || i == 6) {
				switch (i) {
				case 3:
					swapPanelCtrls (0, 3);
					termPanel (1);
					termPanel (2);
					break;
				case 6:
					swapPanelCtrls (3, 6);
					termPanel (4);
					termPanel (5);
					break;
				}
			} 
			else {
				initPanel (i);
			}
		} 
		else if (!ps) {
			switch (i) {
			case 0:
				initPanel (0);
				break;
			case 1:
				initPanel (0);
				initPanel (1);
				break;
			case 2:
				initPanel (0);
				initPanel (1);
				initPanel (2);
				break;
			case 3:
				initPanel (3);
				break;
			case 4:
				initPanel (4);
				initPanel (3);
				break;
			case 5:
				initPanel (5);
				initPanel (4);
				initPanel (3);
				break;
			case 6:
				initPanel (6);
				break;
			case 7:
				initPanel (7);
				initPanel (6);
				break;
			case 8:
				initPanel (8);
				initPanel (7);
				initPanel (6);
				break;
			}
		}
	}

	//panel icon initializer
	void initPanel( int num){
			panelCtrl = panelCtrls [num].GetComponent<panelController> ();
			anim = panelCtrls [num].GetComponent<Animator> ();
			panelCtrl.changeState ();
			panelCtrl.initPointer (panelCtrl.getState());
			anim.SetBool ("intro", panelCtrl.getState());
	}

	//panel icon terminator
	void termPanel( int num){
		panelCtrl = panelCtrls [num].GetComponent<panelController> ();
		anim = panelCtrls [num].GetComponent<Animator> ();
		panelCtrl.changeState ();
		anim.SetBool ("outro", true);
		anim.SetBool ("intro", false);
		//panelCtrl.terminatePointer ();
	}
	// panel icon swapper
	private void swapPanelCtrls(int a, int b)
	{
		Animator anim1 = panelCtrls [a].GetComponent<Animator> ();
		Animator anim2 = panelCtrls [b].GetComponent<Animator> ();
		panelCtrls [b].GetComponent<panelController> ().changeState ();
		panelCtrls [b].GetComponent<panelController> ().initPointer (panelCtrls [b].GetComponent<panelController> ().getState());
		anim1.SetBool("outro", true);
		anim1.SetBool("intro", false);
		anim2.SetBool ("intro", true);
	}

	void CountDownCheck(float time){
		if (time > -4f && time < -3f) {
			countdownAnim.Play ("start");
		} else if (time > -3f && time < -2f) {
			countdownText.text = "2";
		} else if (time > -2f && time < -1f) {
			countdownText.text = "1";
		} else if (time > -1f && time < -.3f) {
			countdownText.text = "GO!";
		} else if (time > -.3f) {
			countdownAnim.Play ("stop");
		}
	}

	void OnApplicationQuit(){
		PlayerPrefs.SetString ("Selection", "Main Menu");
	}
}
