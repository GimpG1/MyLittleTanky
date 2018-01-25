using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour 
{
	[SerializeField] ObjectsFUEL fuel;
	[SerializeField] ObjectsAMMUNATION ammo;
	[SerializeField] HeroStats hero;
	private bool _isActive = false;

	private void Awake()
	{
		if (fuel == null) 
		{
			fuel = gameObject.GetComponent<ObjectsFUEL> ();
			fuel.SetGetFuel = Random.Range (20, 100);
		}
		if (ammo == null) 
		{
			ammo = gameObject.GetComponent<ObjectsAMMUNATION> ();
			ammo.SetGetAmmunation = Random.Range (2,20);
		}
		if (hero == null)
		{
			hero = GameObject.Find("HeroTank").GetComponent<HeroStats>();
		}
	}

	private void Update()
	{
		gameObject.GetComponent<MeshRenderer> ().enabled = _isActive;
	}

	public bool SetBonusActive
	{
		get
		{
			return _isActive;
		}
		set
		{ 
			_isActive = value;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			hero.SetFuel += fuel.SetGetFuel;
			hero.SetAmmo += ammo.SetGetAmmunation;
			SetBonusActive = false;
		}
	}
}
