using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakashiGenerator : MonoBehaviour {

	public GameObject[] list;
	public Transform trans;

	//private variabless
	private bool startTheSpawn;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void spawn(){
		float val = Random.Range(-1.0f, 1.0f);
		float position = 0;
		if (val > 0) {
			position = trans.position.y; 
			position = position + Random.Range (-2f, 2f);
			if (position > 3) {
				position = 3;
			}else if(position<-3){
				position = -3;
			}

			SpawnObject (0, position);
		}
		else{
			position = Random.Range (-3f, 3f);
			SpawnObject (1, position);
		}
	}
	void SpawnObject(int index, float position)
	{
		
		Instantiate (list[index], new Vector3 (9, position , 0), Quaternion.identity);

		Invoke ("spawn", Random.Range (4.0f, 6.0f));
	}
}
