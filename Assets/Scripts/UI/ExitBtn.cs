using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBtn : MonoBehaviour {

	void OnTriggerEnter (Collider col){
		Debug.Log ("Quiting");
		Application.Quit ();
	}
}
