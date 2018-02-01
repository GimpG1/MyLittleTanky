using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAreasController : MonoBehaviour 
{
	[SerializeField] CameraController _myCamAudio;
	enum SoundArea
	{
		Default = 0,
		Desert = 1,
		Forest = 2,
		Oaza = 3
	}

	private void Update()
	{
		_myCamAudio.ChangeGroundSound (0);
	}
}
