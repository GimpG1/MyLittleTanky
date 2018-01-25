using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageHealthBar : MonoBehaviour 
{
	[SerializeField] Slider _healthBar;
	[SerializeField] Turrent _turrent;
	private int _currentHP;
	private void Awake() 
	{
		if (_turrent == null) 
		{
			_turrent = GameObject.Find ("Turret").GetComponent<Turrent> ();
		}
	}

	private void Start ()
	{
		_healthBar.maxValue = _turrent.GetComponentInChildren<ObjectsHP>().SetGetHp;
		_healthBar.value = _turrent.GetComponentInChildren<ObjectsHP>().SetGetHp;
		CurrentHP = _turrent.GetComponentInChildren<ObjectsHP>().SetGetHp;
	}
	private void Update () 
	{
		if (_turrent.IsDamaged == true) {
			_healthBar.value = _turrent.GetComponentInChildren<ObjectsHP>().SetGetHp;
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
