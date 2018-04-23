using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
	public GameObject moreTimeBox;
	
	public Text timeText;
	public GameManager gameManager;
	private float countUp;
	private float totalTime;
	Coroutine coroutine;
	private AudioManager audioManager;

	void Awake()
	{
		totalTime = 35;
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
		InvokeRepeating("CountDown", 0f, 1f);
	}

	
	public void MoreTime() // add more 15 seconds
	{
		audioManager.PlayMoreTime();
		totalTime += 15;
		moreTimeBox.SetActive(true);
		coroutine = StartCoroutine(ShowFor(2f));
		//timeBarImage.sprite = timerBarSprites[0];
	}

	void CountDown()
	{
		countUp += 1f;
		//timerBarRect.sizeDelta = new Vector2((countUp/totalTime)*100f,10f);
//		if (countUp > (2*totalTime) / 3)
//		{
//			//timeBarImage.sprite = timerBarSprites[1];
//			
//		}
		timeText.text = (totalTime - countUp).ToString();
		

		if (totalTime<countUp)
		{
			GameOver();
			enabled = false;
		}
	}


	private void GameOver()
	{
		CancelInvoke();
		gameManager.GameOver();
	}

	IEnumerator ShowFor(float time)
	{
		yield return new WaitForSeconds(time);
		moreTimeBox.SetActive(false);
		StopCoroutine(coroutine);
	}
}
