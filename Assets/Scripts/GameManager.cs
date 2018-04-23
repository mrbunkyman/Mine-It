using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public Drill drill;
	public Button startButton;
	
	public Text scoreText;
	public Text requiredScoreText;

	public ResetBox resetBox;
	
	public Timer timer;
	private int currentScore;
	private int requiredScore;
	private int highestRecordedScore;
	private AudioManager audioManager;
	public void AddScore(int score)
	{
		this.currentScore += score;
		scoreText.text = currentScore.ToString();
		if (this.currentScore >= requiredScore)
		{
			timer.MoreTime();
			UpdateRequiredScore();
		}
	}

	public void UpdateRequiredScore()
	{
		requiredScore += 300;
		requiredScoreText.text = requiredScore.ToString();
	}
	public int GetScore()
	{
		return currentScore;
	}

	public void ShareScoreOnTwitter()
	{
		SocialMediaSharingUtil.ShareOnTwitter(currentScore);
	}

	public void StartGame()
	{
		drill.enabled = true;
		startButton.gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	public void GameOver()
	{
		audioManager.PlayGameOver();
		if (currentScore > highestRecordedScore)
		{
			PlayerPrefs.SetInt("HighestScore", currentScore);
			highestRecordedScore = currentScore;
			resetBox.IsHighestScore(true);
		}
		else
		{
			resetBox.IsHighestScore(false);
		}
		Debug.Log(highestRecordedScore);
		Time.timeScale = 0;
		resetBox.SetScore(currentScore);
		resetBox.SetHighestScore(highestRecordedScore);
		resetBox.Show();

	}

	public void Reset()
	{
		SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		Time.timeScale = 1;
	}

	void Awake()
	{
		Time.timeScale = 0;
		startButton.gameObject.SetActive(true);
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
		audioManager.PlayObtainDiamond();
	}
	// Use this for initialization
	void Start ()
	{
		currentScore = 0;
		requiredScore = 100;
		scoreText.text = currentScore.ToString();
		requiredScoreText.text = requiredScore.ToString();
		LoadHighestScore();
	}

	void LoadHighestScore()
	{
		if (PlayerPrefs.HasKey("HighestScore"))
		{
			highestRecordedScore = PlayerPrefs.GetInt("HighestScore");
		}
		else
		{
			highestRecordedScore = 0;
			PlayerPrefs.SetInt("HighestScore", 0);
		}
	}
	
	
	
}
