using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioClip gameOver;
	public AudioClip hitSomething;
	public AudioClip moreTime;
	public AudioClip obtainDiamond;
	public AudioClip obtainDirt;
	public AudioClip obtainOre;
	public AudioClip scrolling;
	
	private AudioSource audioSouce;

	public void PlayGameOver()
	{
		audioSouce.PlayOneShot(gameOver,1f);
	}
	
	public void PlayHitSomething()
	{
		audioSouce.PlayOneShot(hitSomething, 0.5f);
	}

	public void PlayMoreTime()
	{
		audioSouce.PlayOneShot(moreTime);
	}

	public void PlayObtainDiamond()
	{
		audioSouce.PlayOneShot(obtainDiamond);
	}

	public void PlayObtainDirt()
	{
		audioSouce.PlayOneShot(obtainDirt);
	}

	public void PlayObtainOre()
	{
		audioSouce.PlayOneShot(obtainOre);
	}

	public void PlayScrolling()
	{
		audioSouce.PlayOneShot(scrolling,0.1f);
	}
	
	void Awake()
	{
		audioSouce = gameObject.GetComponent<AudioSource>();
	}
	
	
	

}
