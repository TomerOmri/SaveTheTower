using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBtn : MonoBehaviour {
	const int TheGame = 1;
	// Use this for initialization

	void OnTriggerEnter (Collider col){
		Debug.Log ("got in");
		SceneManager.LoadScene (TheGame);
	}
}
