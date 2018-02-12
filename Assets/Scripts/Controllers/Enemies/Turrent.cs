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
	[SerializeField] DamagedController _isDamaged;
    [SerializeField] TurretShoot _turShot;
	private Vector3 _defPos;
	#endregion

	private void Awake()
	{
		if (hero == null ||
			_turretHP == null ||
			detector == null ||
			defeatBonus == null ||
			_isDamaged == null)

		{
			hero = GameObject.Find("Tanky").GetComponent<HeroStats>();
			_turretHP = gameObject.GetComponent<ObjectsHP> ();
			detector = gameObject.GetComponent<DetectPlayer> ();
			defeatBonus = GameObject.Find("DefeatBonus").GetComponent<BonusController> ();
			_isDamaged = gameObject.GetComponent<DamagedController> ();

			_turretHP.SetGetHp = 300;
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
            float distance = Vector3.Distance(transform.position, detector.HeroTransform.position);
            _turShot.TakeAction(distance * 1000);
            _isDamaged.SetGetDamaged = false;
		}
	}

	private void TurrentAttack(Transform player)
	{
		Vector3 direction = player.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (direction);
		Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, 3f* Time.deltaTime).eulerAngles;
		transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.CompareTag("Terrain"))
		{
			TakeDamage(hero.GetComponentInChildren<ObjectsAttackPOWER>().SetGetAttackPower);
			_isDamaged.SetGetDamaged = true;
			if (_turretHP.SetGetHp <= 0) 
			{
				defeatBonus.SetBonusActive = true;
				defeatBonus.SpawnPlace (new Vector3(transform.position.x - 3,transform.position.y + 1, transform.position.z - 3));
				Destroy(gameObject);
			}
		}
	}

	public void TakeDamage(int damage)
	{
		_turretHP.SetGetHp -= damage;
	}

}
