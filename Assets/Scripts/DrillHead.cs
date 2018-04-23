using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillHead : MonoBehaviour
{
	public Drill drill;
	public BonusScore bonusScoreBox;
	private Rigidbody2D rb;
	private BoxCollider2D box;
	private bool isLocked;
	private AudioManager audioManager;

	public void SetBonusScore(int bonus)
	{
		bonusScoreBox.SetBonusScore(bonus);
		bonusScoreBox.Show();
	}
	public void Lock()
	{
		isLocked = true;
	}

	public void Unlock()
	{
		isLocked = false;
	}
	public bool IsLock()
	{
		return isLocked;
	}
	public void DecreaseVelocity(float percent)
	{
		HitSomething();
		rb.velocity = percent * rb.velocity;	
	}

	public float GetDistanceFromDrillToBase()
	{
		return drill.GetDistanceFromDrillToBase();
	}
	void Awake()
	{
		box = gameObject.GetComponent<BoxCollider2D>();
		rb = gameObject.GetComponent<Rigidbody2D>();
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
	}

	void HitSomething()
	{
		audioManager.PlayHitSomething();

		rb.velocity = -rb.velocity;
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Border"))
		{
			Lock();
			HitSomething();
		}
	}
}
