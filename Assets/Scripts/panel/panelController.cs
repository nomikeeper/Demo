using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelController : MonoBehaviour {

	//private variables
	private bool state;
	// Use this for initialization
	void Start () {
		state = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void initPointer(bool newState){
		gameObject.SetActive (newState);
	}

	public void terminatePointer(){
		gameObject.SetActive (false);
	}
	public void changeState()
	{
		state = !state;
	}
	public bool getState(){
		return state;
	}
}
