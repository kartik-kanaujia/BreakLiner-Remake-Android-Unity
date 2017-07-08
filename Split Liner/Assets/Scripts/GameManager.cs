using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	public PlayerMotor motor;
	public SpawnManager sm;
	public AudioManager am;

	public Text tempScoreText;
	public Text highScoreText;

	public int tempScore = 1;
	public int highScore = 0;

	public AudioSource powerUp;

	public Slider slider;

	public float lookTimer = 0f;
	public float timerDuration = 2f;
	public float startingAmount = 1f;
	public float currentAmount;

	public PlayGamesScript pg;

	// Use this for initialization
	void Start () 
	{
		motor = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMotor> ();
		sm = GameObject.FindGameObjectWithTag ("SM").GetComponent<SpawnManager> ();
		am = GameObject.FindGameObjectWithTag ("AM").GetComponent<AudioManager> ();
		pg = GameObject.FindGameObjectWithTag ("PG").GetComponent<PlayGamesScript> ();

		highScoreText.text = PlayerPrefs.GetInt ("score").ToString ();
		highScore = PlayerPrefs.GetInt ("score");

		if (am.reloadScore == false)
		{
			tempScore = highScore;
		}
		else
		if (am.reloadScore == true)
		{
			tempScore = am.tempScore;
			motor.buttonEnabled = false;
			Time.timeScale = 0.5f;
			StartCoroutine (endSlomo(0.5f));
		}

		if (highScore == 0)
		{
			tempScore = 1;
		}

		currentAmount = startingAmount;

	}
	
	// Update is called once per frame
	void Update () 
	{
//		if (motor.gameOver == true)
//		{
//			StartCoroutine (ExecuteAfterTime (3f));
//		}

		if (Input.GetKeyDown(KeyCode.Escape)) {Application.Quit();}



		if (tempScore == 0)
		{
			Time.timeScale = 0.5f;
			StartCoroutine (endSlomo (0.5f));
			highScore++;
			tempScore = highScore;
			tempScoreText.color = Color.red;
			tempScoreText.fontSize = 100;
			powerUp.Play ();
		}


		if (tempScore < 0)
		{
			tempScore = 0;
		}




		tempScoreText.text = tempScore.ToString ();
		am.tempScore = tempScore;

		if(motor.isLookedAt)
		{
			lookTimer += Time.deltaTime;
			currentAmount -= 0.5f * Time.deltaTime;
			SetUI ();
		}

		if (slider.value <= 0)
		{
			OnGameEnd ();
		}

	}

	public void DecrementTemp()
	{
		tempScore--;
		tempScoreText.color = Color.yellow;
		tempScoreText.fontSize = 60;
		StartCoroutine (ScoreWait (0.3f));
	}

	public void EndTheGame()
	{
		StartCoroutine (ExecuteAfterTime (1f));
	}

	public void OnGameEnd()
	{
		if (PlayerPrefs.GetInt ("score") < highScore)
		{
			PlayerPrefs.SetInt ("score", highScore);
			PlayGamesScript.AddScoreToLeaderboard (SplitLinerResources.leaderboard_leaderboard, highScore);
		}

		SceneManager.LoadScene ("Game");
		am.allowChance = true;
	}

	IEnumerator ExecuteAfterTime (float time)
	{
		yield return new WaitForSeconds (time);
	
		OnGameEnd ();
	}
	IEnumerator ScoreWait (float time)
	{
		yield return new WaitForSeconds (time);

		tempScoreText.color = Color.clear;
	}
	IEnumerator endSlomo(float time)
	{
		yield return new WaitForSeconds (time);

		Time.timeScale = 1f;
	}

	public void SetUI()
	{
		slider.value = currentAmount;
	}

	public void ShowAchievements()
	{
		if (am.isSignedIn == true)
		{
			PlayGamesScript.ShowAchievementsUI ();
		}
		else
		{
			pg.ToActivate ();
		}
	}

	public void ShowLeaderboards()
	{
		if (am.isSignedIn == true)
		{
			PlayGamesScript.ShowLeaderboardsUI ();
		}
		else
		{
			pg.ToActivate ();
		}
	}

	public void SignInIfNot()
	{
		if (am.isSignedIn == true)
		{
			return;
		}
		else
		{
			pg.ToActivate ();
		}
	}
}
