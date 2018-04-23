using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
[RequireComponent(typeof(Button))]
public class AdsManager: MonoBehaviour
{
	public Drill drill;
	public GameManager gameManager;
	private string googlePlayId = "1605589";
	private string placementId = "rewardedVideo";

	void Start ()
	{    
		if (Advertisement.isSupported) {
			Advertisement.Initialize (googlePlayId, true);
		}
	}

	public void ShowAd ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show(placementId, options);
	}

	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished)
		{
			drill.IncreaseSkillQuantityBy(5);

		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
		gameManager.Reset();
	}
}