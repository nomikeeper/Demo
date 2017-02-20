using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offset_scroller : MonoBehaviour {

	//public variables
	public float scrollSpeed = 1.0f;
	public Renderer rend;
	//private variables
	Vector2 savedOffset;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		savedOffset = rend.sharedMaterial.GetTextureOffset ("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 move = new Vector2 (x, savedOffset.y);
		rend.sharedMaterial.SetTextureOffset ("_MainTex",move);
	}

	void OnDisable(){
		rend.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}
