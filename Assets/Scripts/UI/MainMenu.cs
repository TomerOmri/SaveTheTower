﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public void startNewGame(){
		SceneManager.LoadScene (1);
		//GameManager.Instance.SetActiveGameCanvas (true);
	}

	public void showMainMenu(){
		gameObject.SetActive (true);
	}


	public void hideMainMenu(){
		gameObject.SetActive (false);
	}

	/*public void howToPlay(){
		//gameObject
	}*/
}
