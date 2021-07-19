using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // Variables for the spawning point and the type of enemy(prefab) to spawn
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    private DeckManager deckManager;

    // Variable to control the time between each enemy spawn
    [SerializeField] private float timeBetweenSpawn = 1f;
    private float timer = 2f;

    // Number of enemy to spawn at a time
    private int numOfSpawn = 1;
    public static int numToSpawn = 0;
    public static int numOfEnemyAlive = 0;

    // Number of wave
    public static int wave = 0;

    // Boolean value to determine if wave ended
    public static bool waveEnd = false;
    [SerializeField] private DayNightSystem dayNightSystem;

	private void Start()
	{
        numToSpawn = 0;
        numOfEnemyAlive = 0;
        wave = 0;
        waveEnd = false;
        deckManager = GameObject.Find("DeckManager").GetComponent<DeckManager>();
    }

	void Update()
    {
		timer -= Time.deltaTime;

		if (timer <= 0f && numToSpawn > 0)
		{
            SpawnEnemy();
			timer = timeBetweenSpawn;
		}

        if (numOfEnemyAlive <= 0 && numToSpawn <= 0 && waveEnd == true)
		{
            deckManager.DealingTurret();
            deckManager.DealingTetris();
            waveEnd = false;
            dayNightSystem.DayTime();
		}
	}

    // Method to spawn enemy
    void SpawnEnemy()
    {
        for (int i = 0; i < numOfSpawn; i++)
        {
            numToSpawn--;
            Debug.Log("Enemy spawned");
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            numOfEnemyAlive++;
            Debug.Log(numOfEnemyAlive);
            Debug.Log(numToSpawn);
            
        }
    }

    public void NextWave()
	{
        waveEnd = false;
        wave ++;
        Debug.Log("Wave number: " + wave);
        DifficultyUpdate();
        dayNightSystem.NightTime();
	}

    // Updates the values associated to game difficulty after every wave
    private void DifficultyUpdate()
	{
        // increase number of enemies per wave by 2 every 2 waves
        numToSpawn = 1 + Mathf.CeilToInt(wave / 2) * 2;

        // After every 5 waves, the spawner will spawn 1 extra enemy at the same time
        if (wave % 5 == 0)
		{
            //numOfSpawn++;
            if (timeBetweenSpawn >= 0.3f)
            {
                timeBetweenSpawn -= 0.1f;
            }
            return;
		}
	}
}
