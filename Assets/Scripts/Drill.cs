using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
public class Drill : MonoBehaviour
{
	public GameObject skillInfoBox;
	public Text skillQuantityText;
	
	public GameObject drillHead;
	public GameObject cord;
	
	private float rotateAngle;
	private float angleToRotate = 60f;
	private float rotateSpeed;
	private Vector3 rotateVector;
	private bool isRotateRight;
	private bool isRotating;
	private float drillVelocity;
	private float distanceFromHeadToBase;
	private Touch touch;
	private int skillQuantity = 0;
	private float tapTime;
	private float timeBetweenTap;

	private bool isSkillUsed;

	private Coroutine coroutine;
	public void ShootTheDrill()
	{
		if (isRotating)
		{
			float angle = transform.eulerAngles.z + 90;
			float x = drillVelocity * Mathf.Cos(angle * Mathf.Deg2Rad);
			float y = drillVelocity * Mathf.Sin(angle * Mathf.Deg2Rad);
			drillHead.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
			isRotating = false;

		}
	}

	public float GetDistanceFromDrillToBase()
	{
		return Vector2.Distance(transform.position, drillHead.transform.position);
	}

	public void IncreaseSkillQuantityBy(int quantity)
	{
		skillQuantity += quantity;
		UpdateSkillQuantityText();
		SaveSkillQuantity();
	}

	void Awake()
	{
		isSkillUsed = false;
		timeBetweenTap = 0.3f;
		skillQuantity = 10;
		drillVelocity = 5f;
		isRotating = true;
		rotateAngle = 60f;
		rotateVector = new Vector3(0f, 0f, 1f);
		rotateSpeed = 50f;
		isRotateRight = true;
	}

	void Start()
	{
		
		LoadSkillQuantity();	
//		skillQuantity = 10;
		//SaveSkillQuantity();
		UpdateSkillQuantityText();
	}

	void Update()
	{
		RotateTheDrill();
		Touch();
	}

	void RotateTheDrill()
	{
		if (isRotating)
		{
			if (isRotateRight)
			{
				if (transform.eulerAngles.z >= 180 + angleToRotate)
				{
					isRotateRight = false;
					rotateSpeed = -rotateSpeed;
				}
			}
			else
			{
				if (transform.eulerAngles.z <= 180 - angleToRotate)
				{
					isRotateRight = true;
					rotateSpeed = -rotateSpeed;
				}
			}
			transform.Rotate(rotateVector * rotateSpeed * Time.deltaTime);
		}
		else
		{
			distanceFromHeadToBase = GetDistanceFromDrillToBase();
			if (distanceFromHeadToBase < 0.2f)
			{
				isRotating = true;
				drillHead.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				drillHead.transform.localPosition = new Vector2(0f, 0.21f);
				drillHead.GetComponent<DrillHead>().Unlock();
				isSkillUsed = false;
			}
			cord.transform.localScale = new Vector2(0.1f, distanceFromHeadToBase * 3.1f);
		}
	}

	void Touch()
	{
		if (Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);
			switch (touch.phase)
			{
				case TouchPhase.Ended:
					
					
					if ((tapTime + timeBetweenTap > Time.time) && (skillQuantity>0) && drillHead.GetComponent<DrillHead>().IsLock() && !isSkillUsed )
					{
						isSkillUsed = true;
						Debug.Log("use skill");
						skillQuantity--;
						UpdateSkillQuantityText();
						SaveSkillQuantity();
						tapTime = Time.time;
						SkillUsed();
						return;
					}
					tapTime = Time.time;
					ShootTheDrill();
					break;
            
			}
		} 
	}

	void LoadSkillQuantity()
	{
		if (!PlayerPrefs.HasKey("SkillQuantity"))
		{
			
			PlayerPrefs.SetInt("SkillQuantity", 0);
			skillQuantity = 0;
		}
		else
		{
			skillQuantity = PlayerPrefs.GetInt("SkillQuantity");
			if (skillQuantity > 0)
			{
				ShowSkillInfo();
				coroutine = StartCoroutine(ShowFor(1f));
			}
		}
	}

	void SaveSkillQuantity()
	{
		PlayerPrefs.SetInt("SkillQuantity", skillQuantity);
		Debug.Log("Save " + skillQuantity);
	}

	void UpdateSkillQuantityText()
	{
		skillQuantityText.text = skillQuantity.ToString();
	}

	void SkillUsed()
	{
		Rigidbody2D rb = drillHead.GetComponent<Rigidbody2D>();
		rb.velocity = rb.velocity.normalized * drillVelocity;
	}

	void ShowSkillInfo()
	{
		skillInfoBox.SetActive(true);
	}

	void HideSKillInfo()
	{
		skillInfoBox.SetActive(false);
	}

	IEnumerator ShowFor(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		HideSKillInfo();
		StopCoroutine(coroutine);
	}

}
