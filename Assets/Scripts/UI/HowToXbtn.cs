using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToXbtn : MonoBehaviour {

	public GameObject menuCanvas;

	void OnTriggerEnter (Collider col){
		gameObject.SetActive (false);
		menuCanvas.gameObject.SetActive (true);
	}
}
