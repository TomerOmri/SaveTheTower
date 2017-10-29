using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbtn : MonoBehaviour {

	public GameObject menuCanvas;
	public GameObject thisCanvas;

	void OnTriggerEnter (Collider col){
		Debug.Log ("xbuttn enter");
		thisCanvas.gameObject.SetActive (false);
		menuCanvas.gameObject.SetActive (true);
	}
}
