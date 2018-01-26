using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetProjectile : MonoBehaviour 
{
	private ObjectsAttackPOWER _ammoPower;

	private void Awake() 
	{
		_ammoPower = gameObject.GetComponent<ObjectsAttackPOWER>();
		_ammoPower.SetGetAttackPower = 20;
	}
}
