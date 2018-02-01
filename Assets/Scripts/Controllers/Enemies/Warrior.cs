﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour 
{
	#region Private Variables
	[SerializeField] HeroStats hero;
	[SerializeField] DetectPlayer detector;
	[SerializeField] ObjectsHP _warriorHP;
	[SerializeField] AmmoForcePOWER _warriorAmmoForce;
	[SerializeField] BonusController defeatBonus;
	[SerializeField] DamagedController _isDamaged;
	[SerializeField] AmmunationController _controlAmmo;
	[SerializeField] Vector3 _defaultPos;
	#endregion


	private void Awake()
	{
		if (hero == null ||
			_warriorHP == null ||
			detector == null ||
			defeatBonus == null ||
			_isDamaged == null ||
			_warriorAmmoForce == null)

		{
			hero = GameObject.Find("Tanky").GetComponent<HeroStats>();
			_warriorHP = gameObject.GetComponent<ObjectsHP> ();
			detector = gameObject.GetComponent<DetectPlayer> ();
			defeatBonus = GameObject.Find("DefeatBonus").GetComponent<BonusController> ();
			_isDamaged = gameObject.GetComponent<DamagedController> ();
			_controlAmmo = gameObject.GetComponentInChildren<AmmunationController> ();
			_warriorAmmoForce = gameObject.GetComponent<AmmoForcePOWER> ();
			_defaultPos = gameObject.transform.position;
			_warriorHP.SetGetHp = 100;
			_warriorAmmoForce.SetGetAmmoPower = 600f;
		}
	}

	private void Update()
	{
		if (detector.IsDetected)
		{
			WarriorAttack (detector.HeroTransform);
			_isDamaged.SetGetDamaged = false;
        }
    }

	private void WarriorAttack(Transform player)
	{
		if (player != null) {
			Vector3 direction = player.position - transform.position;
			Quaternion lookRotation = Quaternion.LookRotation (direction);
			Vector3 rotation = Quaternion.Lerp (transform.rotation, lookRotation, 3f * Time.deltaTime).eulerAngles;
			transform.rotation = Quaternion.Euler (0f, rotation.y, 0f);_controlAmmo.TakeAction (_warriorAmmoForce.SetGetAmmoPower);
		} else
			transform.position = _defaultPos;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.CompareTag("Terrain"))
		{
			TakeDamage(hero.GetComponentInChildren<ObjectsAttackPOWER>().SetGetAttackPower);
			_isDamaged.SetGetDamaged = true;
			if (_warriorHP.SetGetHp <= 0) 
			{
				defeatBonus.SetBonusActive = true;
				defeatBonus.SpawnPlace (new Vector3(transform.position.x - 3, transform.position.y + 1, transform.position.z - 3));
				gameObject.SetActive (false);
			}
		}
	}
	public void TakeDamage(int damage)
	{
		_warriorHP.SetGetHp -= damage;
	}
}
