using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	public WaveSpawner waveSpawner;
	private bool pause = false;

	public void NextWave()
	{
		waveSpawner.NextWave();
	}

	public void PauseGame()
	{
		pause = !pause;
		if (pause)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}
}
