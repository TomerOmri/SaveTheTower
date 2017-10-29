using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		init ();
	}
		
	private void init(){
		for (int i = 1; i <= 10; i++) {
			Text ScoreText = GameObject.FindWithTag("Score" + i.ToString ()).GetComponent<Text>();
			ScoreText.text =( PlayerPrefs.GetInt ("Score" + i.ToString ())).ToString();
		}
	}

	public void hideScoreBox(){
		gameObject.SetActive (false);
	}

	public void showScoreBox(){
		gameObject.SetActive (true);
	}
}
