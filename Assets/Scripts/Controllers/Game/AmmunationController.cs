﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunationController : MonoBehaviour 
{
	// Take ammo and shoot
	[SerializeField] ProjectileHandler _handAmmo;
	[SerializeField] GameObject _ammo;

	private void Start()
	{
		if (_handAmmo == null) 
		{
			_handAmmo = GameObject.Find ("ProjectileHandler").GetComponent<ProjectileHandler> ();
		}
	}
	public void TakeAction(float forcePower)
	{
		_ammo = _handAmmo.Pull ();
		Rigidbody Arb = _ammo.GetComponent<Rigidbody> ();
		_ammo.transform.position = transform.position;
		Arb.AddForce (transform.forward * forcePower);
	}
}
