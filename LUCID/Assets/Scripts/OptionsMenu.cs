using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
	[SerializeField] private AudioMixer audioMixer;
	[SerializeField] private GameObject optionsMenu;
	[SerializeField] private AudioSource buttonSound;
	private static bool sound = true;

	private void Start() 
	{
		optionsMenu.SetActive(false);
	}

	public void OffSettings()
	{
		optionsMenu.SetActive(false);
		buttonSound.Play();
	}

	public void OnSettings()
	{
		optionsMenu.SetActive(true);
		buttonSound.Play();
	}

	public void SetVolume(float vol)
	{
        if (sound)
        {
            audioMixer.SetFloat("Volume", vol);
        }
		
	}

	public void ToggleSound()
	{
		if (sound)
		{
			sound = false;
			audioMixer.SetFloat("Volume", -80f);
			buttonSound.Play();
		}
		else
		{
			sound = true;
			audioMixer.SetFloat("Volume", 0f);
			buttonSound.Play();
		}
	}
}
