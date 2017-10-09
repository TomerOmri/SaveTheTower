using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeApp : MonoBehaviour {
	private bool destroyMe = false;
	void Awake(){
		InitializeScore ();
		destroyMe = true;
	}

	// Update is called once per frame
	void Update () {
		if (destroyMe)
			DestroyObject (gameObject);
	}

	private void InitializeScore(){
		int defScore = 0;
		//first time you play
		if (PlayerPrefs.HasKey ("Score1") == false) {
			for (int i = 1; i <=10 ; i++) {
				PlayerPrefs.SetInt ("Score" + i.ToString (), defScore);
			}
		}
	}
}
