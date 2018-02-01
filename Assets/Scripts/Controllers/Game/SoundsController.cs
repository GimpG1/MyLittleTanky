using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundsController : MonoBehaviour
{
	[SerializeField] AudioMixer _masterMixer;

	public void SetMusicVolume(float volume)
	{
		_masterMixer.SetFloat ("MusVol",volume);
	}

	public void SetSfxVolume(float volume)
	{
		_masterMixer.SetFloat ("SfxVol",volume);
	}
}
