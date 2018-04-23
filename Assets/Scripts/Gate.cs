using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gate : MonoBehaviour
{
	public GameObject scoreEarnBox;
	public Image backgroundImg;
	public Text scoreText;
	private GameManager gameManager;

	private AudioManager audioManager;
	//private DrillHead drillHead;
	private Coroutine coroutine;

	void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Ore"))
		{
			
			Debug.Log("obtained something");
			int score = other.GetComponent<Ore>().GetTotalScore();
			if (score > 0)
			{
				if(score>=150)//hit diamond 
					audioManager.PlayObtainDiamond();
				audioManager.PlayObtainOre();
				backgroundImg.color = Color.green;
			}
			else
			{
				audioManager.PlayObtainDirt();
				backgroundImg.color = Color.red;
			}
			scoreEarnBox.SetActive(true);
			coroutine = StartCoroutine(ShowFor(0.5f));
			scoreText.text = score.ToString();
			gameManager.AddScore(score);
			Destroy(other.gameObject);
		}
	}

	IEnumerator ShowFor(float time)
	{
		yield return new WaitForSeconds(time);
		scoreEarnBox.SetActive(false);
		StopCoroutine(coroutine);
	}
}
