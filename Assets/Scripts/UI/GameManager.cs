using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] private Text fpsTest; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_fpsTest ();
	}

	private void _fpsTest(){
		fpsTest.text = "FPS:" + 1 / Time.deltaTime;
	}


}
