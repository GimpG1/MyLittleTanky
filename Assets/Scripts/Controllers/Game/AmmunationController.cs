using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunationController : MonoBehaviour 
{
	// Take ammo and shoot
	[SerializeField] ProjectileHandler _handAmmo;
	[SerializeField] GameObject _ammo;
	[SerializeField] Transform _heroTR;

	private void Start()
	{
		if (_handAmmo == null) 
		{
			_handAmmo = GameObject.Find ("ProjectileHandler").GetComponent<ProjectileHandler> ();
			_heroTR = GameObject.Find ("Tanky").GetComponent<Transform> ();
		}
	}
	public void TakeAction()
	{
		float speed = 2f * Time.deltaTime;
		_ammo = _handAmmo.Pull ();
		Rigidbody Arb = _ammo.GetComponent<Rigidbody> ();
		_ammo.transform.position = transform.position;
		_ammo.transform.position = Vector3.Slerp (_ammo.transform.position,_heroTR.transform.position,0.5f);
		//Arb.velocity = _ammo.transform.TransformDirection(new Vector3(0,0,speed));
	}
}
