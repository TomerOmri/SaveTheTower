using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		init ();
		hideScoreBox ();
	}

	/*void Awake(){
		
	}*/

	private void init(){
		for (int i = 1; i <= 10; i++) {
			Text timeText = GameObject.FindWithTag("Score" + i.ToString ()).GetComponent<Text>();
			int temp = PlayerPrefs.GetInt("Score"+i.ToString());
			timeText.text = (temp / 60).ToString () + ':' + temp % 60;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void hideScoreBox(){
		gameObject.SetActive (false);
	}

	public void showScoreBox(){
		gameObject.SetActive (true);
	}
}
