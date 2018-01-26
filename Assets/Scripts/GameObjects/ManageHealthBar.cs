using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageHealthBar : MonoBehaviour 
{
	[SerializeField] Slider _healthBar;
	[SerializeField] GameObject _objToHandle;
	private int _currentHP;
	private void Awake() 
	{
		if (_objToHandle == null) 
		{
			_objToHandle = gameObject.GetComponent<GameObject> ();
		}
	}

	private void Start ()
	{
		_healthBar.maxValue = _objToHandle.GetComponentInChildren<ObjectsHP>().SetGetHp;
		_healthBar.value = _objToHandle.GetComponentInChildren<ObjectsHP>().SetGetHp;
		CurrentHP = _objToHandle.GetComponentInChildren<ObjectsHP>().SetGetHp;
	}
	private void Update () 
	{
		if (_objToHandle.GetComponentInChildren<DamagedController>().SetGetDamaged == true) {
			_healthBar.value = _objToHandle.GetComponentInChildren<ObjectsHP>().SetGetHp;
		} 
		else
			return;
	}

	public int CurrentHP
	{
		get
		{
			return _currentHP;
		}
		set
		{ 
			_currentHP = value;
		}
	}
}
