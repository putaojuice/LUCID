using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	[SerializeField] private WaveSpawner waveSpawner;
	[SerializeField] private AudioSource buttonSound;
	private bool pause = false;

	public void NextWave()
	{
		waveSpawner.NextWave();
		buttonSound.Play();
	}

	public void PauseGame()
	{
		buttonSound.Play();
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
