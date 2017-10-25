using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoxBtn : MonoBehaviour {

	public GameObject menuCanvas;
	public GameObject scoreBoardPanel;

	void OnTriggerEnter (Collider col){
		menuCanvas.gameObject.SetActive (false);
		scoreBoardPanel.gameObject.SetActive (true);
	}
}
