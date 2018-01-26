using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour 
{
	[SerializeField] ObjectsFUEL fuel;
	[SerializeField] ObjectsAMMUNATION ammo;
	[SerializeField] HeroStats hero;
	private bool _isActive = false;
	float timeLeft = 12f;

	private void Awake()
	{
		if (fuel == null) 
		{
			fuel = gameObject.GetComponent<ObjectsFUEL> ();
			fuel.SetGetFuel = Random.Range (100, 300);
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
		if (gameObject.GetComponent<MeshRenderer>().enabled) 
		{
			timeLeft -= Time.deltaTime;
		}
		if (timeLeft <= 0f) 
		{
			SetBonusActive = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			hero.GetComponentInChildren<ObjectsFUEL>().SetGetFuel += fuel.SetGetFuel;
			hero.GetComponentInChildren<ObjectsAMMUNATION>().SetGetAmmunation += ammo.SetGetAmmunation;
			SetBonusActive = false;
			timeLeft = 12f;
		}
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

	public void SpawnPlace(Vector3 spawnPos)
	{
		transform.position = spawnPos;
	}
}
