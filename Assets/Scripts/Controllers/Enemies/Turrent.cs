using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour 
{
	#region Private Variables
	[SerializeField] HeroStats hero;
	[SerializeField] DetectPlayer detector;
	[SerializeField] ObjectsHP _turretHP;
	[SerializeField] BonusController defeatBonus;
	private bool _turretDamaged;
	private Vector3 _defPos;
	#endregion

	private void Awake()
	{
		if (hero == null)
		{
			hero = GameObject.Find("HeroTank").GetComponent<HeroStats>();
		}
		if (_turretHP == null) 
		{
			_turretHP = gameObject.GetComponent<ObjectsHP> ();
			_turretHP.SetGetHp = 300;
		}
		if (detector == null) 
		{
			detector = gameObject.GetComponent<DetectPlayer> ();
		}
		if (defeatBonus == null) 
		{
			defeatBonus = GameObject.Find("DefeatBonus").GetComponent<BonusController> ();
		}
	}

	private void Start()
	{
		_defPos = transform.position;
	}
	private void Update()
	{
		if (detector.IsDetected)
		{
			TurrentAttack (detector.HeroTransform);
			transform.position = _defPos;
			IsDamaged = false;
		}
	}

	private void TurrentAttack(Transform player)
	{
		Vector3 direction = player.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (direction);
		Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, 3f* Time.deltaTime).eulerAngles;
		transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	public void TakeDamage(int damage)
	{
		_turretHP.SetGetHp -= damage;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.CompareTag("Terrain"))
		{
			TakeDamage(hero.GetComponentInChildren<ObjectsAttackPOWER>().SetGetAttackPower);
			IsDamaged = true;
			if (_turretHP.SetGetHp <= 0) 
			{
				defeatBonus.SetBonusActive = true;
				defeatBonus.SpawnPlace (new Vector3(transform.position.x + 10,transform.position.y + 1, transform.position.z));
				Destroy(gameObject);
			}
		}
	}
	public bool IsDamaged
	{
		get
		{
			return _turretDamaged;
		}
		set
		{ 
			_turretDamaged = value;
		}
	}
}
