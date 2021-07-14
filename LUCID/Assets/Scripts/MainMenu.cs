using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private AudioMixer audioMixer;
	public GameObject optionsMenu;

	private void Start() 
	{
		optionsMenu.SetActive(false);	
	}

	public void PlayGame()
	{
		// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		// GameLevel scene code from build setting
		SceneManager.LoadScene(1);
	}

	public void CloseMenu()
	{
		optionsMenu.SetActive(false);
	}

	public void OnMenu()
	{
		optionsMenu.SetActive(true);
	}

	public void SetVolume(float vol)
	{
		audioMixer.SetFloat("Volume", vol);
	}
}
