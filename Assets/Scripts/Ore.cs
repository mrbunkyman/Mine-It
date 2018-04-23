using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
	
	public float minSpeed;
	public float maxSpeed;
	public int score;
	public float decreaseVelocity;

	private float bonusScore;
	private int BASE_BONUS_SCORE;
	private Rigidbody2D rb;
	//private GameObject drillHead;
	private bool isGrabbed;
	private DrillHead drillHead;

	public int GetTotalScore()
	{
		return score + (int)bonusScore;
	}
	
	void Awake()
	{
		BASE_BONUS_SCORE = 15;
		rb = gameObject.GetComponent<Rigidbody2D>();
		//enabled = false;
	}

	void Start()
	{
		rb.velocity = Random.Range(minSpeed, maxSpeed) * Vector2.left;
	}
	void Update()
	{
		if(isGrabbed)
			transform.position = drillHead.gameObject.transform.position;
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("DrillHead"))
		{
	
			drillHead  = other.gameObject.GetComponent<DrillHead>();
			if (drillHead.IsLock() == false)
			{
				if (score > 0)
				{
					bonusScore = drillHead.GetDistanceFromDrillToBase() * BASE_BONUS_SCORE;
					drillHead.SetBonusScore((int)bonusScore);
				}

				drillHead.DecreaseVelocity(decreaseVelocity);
				drillHead.Lock();
				rb.velocity = Vector2.zero;
				isGrabbed = true;
			}
		}

		if (other.gameObject.CompareTag("Border"))
		{
			Destroy(gameObject);
		}
	}
}
