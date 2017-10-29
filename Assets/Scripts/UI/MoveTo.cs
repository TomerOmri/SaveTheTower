using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {

	public GameObject From;
	public GameObject To;

	void OnTriggerEnter (Collider col){
		From.gameObject.SetActive (false);
		To.gameObject.SetActive (true);
	}
}
