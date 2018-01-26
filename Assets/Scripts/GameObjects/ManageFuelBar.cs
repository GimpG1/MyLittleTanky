using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageFuelBar : MonoBehaviour 
{
	[SerializeField] Slider _fuelBar;
	[SerializeField] GameObject _objToHandle;
	private int _currentFuel;

	private void Awake() 
	{
		if (_objToHandle == null) 
			{
				_objToHandle = gameObject.GetComponent<GameObject> ();
			}
	}

	private void Start ()
	{
		_fuelBar.maxValue = _objToHandle.GetComponentInChildren<ObjectsFUEL>().SetGetFuel;
		_fuelBar.value = _objToHandle.GetComponentInChildren<ObjectsFUEL>().SetGetFuel;
		CurrentFuel = _objToHandle.GetComponentInChildren<ObjectsFUEL>().SetGetFuel;
	}
	private void Update () 
	{
		if (_objToHandle.GetComponent<HeroStats>().IsMoving == true) {
			_fuelBar.value = _objToHandle.GetComponentInChildren<ObjectsFUEL>().SetGetFuel;
			} 
			else
				return;
	}

	public int CurrentFuel
	{
			get
			{
				return _currentFuel;
			}
			set
			{ 
				_currentFuel = value;
			}
	}
}
