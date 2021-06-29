using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	// Variables for the spawning point and the type of enemy(prefab) to spawn
	public GameObject enemyPrefab;
	public Transform spawnPoint;

	// Variable to control the time between each enemy spawn
	public float timeBetweenSpawn = 2f;
	private float timer = 2f;

	// Number of enemy to spawn a t a time
	private int numOfSpawn = 1;

	private void Update()
	{
		timer -= Time.deltaTime;

		if (timer <= 0f)
		{
			SpawnEnemy();
			timer = timeBetweenSpawn;
		}
	}

	// Method to sp[awn enemy
	void SpawnEnemy()
	{
		for (int i = 0; i < numOfSpawn; i++)
		{
			Debug.Log("Enemy spawned");
			Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
		}
	}

}
