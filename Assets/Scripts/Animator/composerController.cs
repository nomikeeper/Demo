using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class composerController : MonoBehaviour {

	//private variables

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetBool ("celebrate") == true && anim.GetCurrentAnimatorStateInfo (0).IsName ("celebration") == true) {
			anim.SetBool ("celebrate", false);
		}
	}

	public void celebrate(){
		anim.SetBool ("celebrate", true);
	}
}
