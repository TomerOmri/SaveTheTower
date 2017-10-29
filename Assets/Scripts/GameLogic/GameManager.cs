using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

	private void reset(){
		life = 100;
		score = 0;
		lifeText.text = life.ToString();
		scoreText.text = score.ToString();
	}

	void Awake(){
		instance = this;
	}

	//when player life is <= 0
	private void gameOver(){
		//Time.timeScale = 0;//stop the game
		SaveScore (score);//save the score if need to
		reset();//reset all
		SceneManager.LoadScene(0);//go back to main menu

	}

	/// <summary>
	/// use this function to decent Player life
	/// damage is the amount that you want to decent
	/// </summary>
	/// <param name="damage">Damage.</param>
	public void hitFance(int damage){
        life -= damage;
		lifeText.text = life.ToString ();
		Debug.Log ("GameManger: "+ life.ToString());
		if (life <= 0) {
			gameOver ();
		}
	}

	/// <summary>
	/// use this functin when you want to encrise player score.
	/// </summary>
	/// <param name="_score">Score.</param>
    public void AddScore(int _score)
    {
        score += _score;
        scoreText.text = score.ToString();
    }


	void Update () {
		_fpsTest ();
	}

	private void _fpsTest(){
		fpsTest.text = (1 / Time.deltaTime).ToString("0");
	}

	/// <summary>
	/// The function is saving the score if it is one of the best 10
	/// </summary>
	/// <param name="score">Score.</param>
	public void SaveScore(int score){
		int temp;

		for(int i=1; i<=10; i++)
		{
			if(PlayerPrefs.GetInt("Score"+i.ToString())<score)     //if cuurent score is in top 10
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
