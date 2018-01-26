using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedController : MonoBehaviour {

	private bool _damaged;

	public bool SetGetDamaged
	{
		get
		{
			return _damaged;
		}
		set
		{ 
			_damaged = value;
		}
	}
}
