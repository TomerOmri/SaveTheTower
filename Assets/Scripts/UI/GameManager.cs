using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	private static volatile GameManager instance;
	private static object syncRoot = new Object();
	[SerializeField] private Text fpsTest; 
	private int life = 100;
	private int score = 0;
	[SerializeField] private Text lifeText;
	[SerializeField] private Text scoreText;

	private void startGame(){
		life = 100;
		score = 0;

	}

	public static GameManager Instance {
		get {
			if (instance == null) {
				GameObject obj = new GameObject ("GameManager");
				obj.AddComponent<GameManager> ();
			}

			return instance;
		}
	}

	void Awake(){
		instance = this;
	}

	private void gameOver(){
		
	}

	public void hitFance(int damage){
		life -= damage;
		lifeText.text = life.ToString ();
		Debug.Log ("GameManger: "+ life.ToString());
		if (life <= 0) {
			gameOver ();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_fpsTest ();
	}

	private void _fpsTest(){
		fpsTest.text = (1 / Time.deltaTime).ToString("0");
	}

	public void SaveScore(int score){
		int temp;

		for(int i=1; i<=10; i++)
		{
			if(PlayerPrefs.GetInt("Score"+i.ToString())>score)     //if cuurent score is in top 10
			{
				temp=PlayerPrefs.GetInt("Score"+i.ToString());     //store the old highscore in temp varible to shift it down 
				PlayerPrefs.SetInt("Score"+i.ToString(),score);     //store the currentscore to highscores
				if(i<10)                                        //do this for shifting scores down
				{
					int j=i+1;
					score = PlayerPrefs.GetInt("Score"+j.ToString());
					PlayerPrefs.SetInt("Score"+j.ToString(),temp);    
				}
			}
		}
	}
}
