using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetBox : MonoBehaviour
{

    public Text headerTxt;
    public Text scoreTxt;
    public Text highestScoreTxt;
    public GameManager gameManager;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetHighestScore(int highestScore)
    {
        highestScoreTxt.text = highestScore.ToString();
    }
    public void SetScore(int score)
    {
        scoreTxt.text = score.ToString();
    }

    public void IsHighestScore(bool isHighest)
    {
        if (isHighest)
        {
            headerTxt.text = "HIGHEST SCORE:";
        }
        else
        {
            headerTxt.text = "SCORE:";
        }
    }

    public void ResetButtonClicked()
    {
        gameManager.Reset();
        Hide();
    }
}
