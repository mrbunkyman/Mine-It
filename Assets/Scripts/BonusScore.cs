using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BonusScore : MonoBehaviour
{

	public Text bonusScoreTxt;
	private Coroutine coroutine;
	public void SetBonusScore(int bonusScore)
	{
		bonusScoreTxt.text = bonusScore.ToString();
	}

	public void Show()
	{
		gameObject.SetActive(true);
		coroutine = StartCoroutine(ShowFor(1f));
	}

	public void Hide()
	{
		gameObject.SetActive(false);
		StopCoroutine(coroutine);
	}

	IEnumerator ShowFor(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		Hide();
	}
	
	
}
