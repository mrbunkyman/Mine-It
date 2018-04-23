using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSpawner : MonoBehaviour
{

	public List<GameObject> orePrefabs;
	public Transform spawnLineTop;
	public Transform spawnLineBottom;
	private Vector2 spawnPos;
	private float x;
	private float y;
	
	void Awake()
	{
		InvokeRepeating("SpawnOres", 0f, 3f);
	}

	void SpawnOres()
	{
		int index;
		for (int i = 0; i < 10; i++)
		{
			x = Random.Range(spawnLineTop.position.x, spawnLineBottom.position.x);
			y = Random.Range(spawnLineTop.position.y, spawnLineBottom.position.y);
			index = Random.Range(0, orePrefabs.Count);
			if (orePrefabs[index] != null)
			{
				Instantiate(orePrefabs[index], new Vector2(x, y), Quaternion.identity);
			}
		}
	}
}
