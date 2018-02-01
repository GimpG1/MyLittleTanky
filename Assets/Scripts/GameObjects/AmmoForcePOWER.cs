using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoForcePOWER : MonoBehaviour {
	private float _ammoPower;

	public float SetGetAmmoPower
	{
		get
		{
			return _ammoPower;
		}
		set
		{
			_ammoPower = value;
		}
	}
}
