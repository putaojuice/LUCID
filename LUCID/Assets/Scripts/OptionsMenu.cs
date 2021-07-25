using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
	[SerializeField] private AudioMixer soundOutput;
	[SerializeField] private AudioMixer effectOutput;
	[SerializeField] private GameObject optionsMenu;
	[SerializeField] private AudioSource buttonSound;
	private static bool sound = true;
	private static bool effect = true;

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

	public void SetSoundVolume(float vol)
	{
        if (sound)
        {
            soundOutput.SetFloat("Volume", vol);
        }
		
	}

	public void SetEffectVolume(float vol)
	{
        if (sound)
        {
            effectOutput.SetFloat("Volume", vol);
        }
		
	}

	public void ToggleSound()
	{
		if (sound)
		{
			sound = false;
			soundOutput.SetFloat("Volume", -80f);
			buttonSound.Play();
		}
		else
		{
			sound = true;
			soundOutput.SetFloat("Volume", 0f);
			buttonSound.Play();
		}
	}

	public void ToggleEffect()
	{
		if (effect)
		{
			effect = false;
			effectOutput.SetFloat("Volume", -80f);
			buttonSound.Play();
		}
		else
		{
			effect = true;
			effectOutput.SetFloat("Volume", 0f);
			buttonSound.Play();
		}
	}
}
