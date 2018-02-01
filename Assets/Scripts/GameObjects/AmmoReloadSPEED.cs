using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoReloadSPEED : MonoBehaviour {
	private float _ammoReloadSpeed;

	public float SetGetReloadSpeed
	{
		get
		{
			return _ammoReloadSpeed;
		}
		set
		{
			_ammoReloadSpeed = value;
		}
	}
}
