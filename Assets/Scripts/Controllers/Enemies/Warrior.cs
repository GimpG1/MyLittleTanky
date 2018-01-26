using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour 
{
	#region Private Variables
	[SerializeField] HeroStats hero;
	[SerializeField] DetectPlayer detector;
	[SerializeField] ObjectsHP _warriorHP;
	[SerializeField] BonusController defeatBonus;
	[SerializeField] DamagedController _isDamaged;
	[SerializeField] ProjectileHandler _ammoControl;
	[SerializeField] GameObject ammo;
	#endregion


	private void Awake()
	{
		if (hero == null ||
			_warriorHP == null ||
			detector == null ||
			defeatBonus == null ||
			_isDamaged == null)

		{
			hero = GameObject.Find("HeroTank").GetComponent<HeroStats>();
			_warriorHP = gameObject.GetComponent<ObjectsHP> ();
			detector = gameObject.GetComponent<DetectPlayer> ();
			defeatBonus = GameObject.Find("DefeatBonus").GetComponent<BonusController> ();
			_isDamaged = gameObject.GetComponent<DamagedController> ();
			_ammoControl = GameObject.Find ("ProjectileHandler").GetComponent<ProjectileHandler> ();

			_warriorHP.SetGetHp = 100;
		}
	}

	private void Update()
	{
		if (detector.IsDetected)
		{
			WarriorAttack (detector.HeroTransform);
			_isDamaged.SetGetDamaged = false;
			ammo =_ammoControl.Pull ();
			ammo.transform.position = gameObject.transform.position;
		}
	}
	private void WarriorAttack(Transform player)
	{
		ammo.transform.position = player.transform.position;
	}
	public void TakeDamage(int damage)
	{
		_warriorHP.SetGetHp -= damage;
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
				defeatBonus.SpawnPlace (new Vector3(transform.position.x + 10,transform.position.y + 1, transform.position.z));
				Destroy(gameObject);
			}
		}
	}

}
