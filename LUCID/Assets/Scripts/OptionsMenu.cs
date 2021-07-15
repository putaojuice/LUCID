using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
	[SerializeField] private AudioMixer audioMixer;
	[SerializeField] private GameObject optionsMenu;
	private static bool sound = true;

	private void Start() 
	{
		optionsMenu.SetActive(false);
	}

	public void OffSettings()
	{
		optionsMenu.SetActive(false);
	}

	public void OnSettings()
	{
		optionsMenu.SetActive(true);
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
		}
		else
		{
			sound = true;
			audioMixer.SetFloat("Volume", 0f);
		}
	}
}
