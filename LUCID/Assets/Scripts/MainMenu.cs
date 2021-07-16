using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private AudioMixer audioMixer;
	[SerializeField] private GameObject optionsMenu;
	[SerializeField] private GameObject creditsMenu;
	[SerializeField] private AudioSource buttonSound;
	// private bool sound = true;

	private void Start() 
	{
		// optionsMenu.SetActive(false);
		creditsMenu.SetActive(false);
	}

	public void PlayGame()
	{
		// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		// GameLevel scene code from build setting
		buttonSound.Play();
		SceneManager.LoadScene(1);
	}

	// public void OffSettings()
	// {
	// 	optionsMenu.SetActive(false);
	// }

	// public void OnSettings()
	// {
	// 	optionsMenu.SetActive(true);
	// }

	public void OffCredits()
	{
		creditsMenu.SetActive(false);
		buttonSound.Play();
	}

	public void OnCredits()
	{
		creditsMenu.SetActive(true);
		buttonSound.Play();
	}

	// public void SetVolume(float vol)
	// {
	// 	audioMixer.SetFloat("Volume", vol);
	// }

	// public void ToggleSound()
	// {
	// 	if (sound)
	// 	{
	// 		sound = false;
	// 		audioMixer.SetFloat("Volume", -80f);
	// 	}
	// 	else
	// 	{
	// 		sound = true;
	// 		audioMixer.SetFloat("Volume", 0f);
	// 	}
	// }
}
