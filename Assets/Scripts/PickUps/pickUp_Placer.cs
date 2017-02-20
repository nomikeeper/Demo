using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp_Placer : MonoBehaviour {

	public GameObject[] SongSections;
	public Transform player;
	//private variables
	float speed;
	bool isOver;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("p")) {
			Destroy (gameObject);
		}
	}


}
