using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SocialMediaSharingUtil{

	private const string TWITTER_URL = "http://twitter.com/intent/tweet";

	
	private const string TWEET_LANGUAGE = "en";
	private static string shareContent;

	private const string androidHashtag = "#Android";
	private const string mineItHashtag = "#mineit";
	private const string unityHashTag = "#unity3d";
	private const string mrbunymanHashTag = "#mrbunyman";

	private const string FACEBOOK_APP_ID = "139584299956852";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";

	public static void ShareOnTwitter(int score)
	{
		shareContent = "OMG! This game is so addictive, I scored " + score + " !!! " + mineItHashtag + " " + androidHashtag + " " + unityHashTag + " " + mrbunymanHashTag;
		Application.OpenURL(TWITTER_URL + "?text=" + WWW.EscapeURL(shareContent));
	}

	public static void ShareOnFacebook(int score)
	{
		shareContent = "OMG! This game is so addictive, I scored " + score + " !!! ";
	}
}
