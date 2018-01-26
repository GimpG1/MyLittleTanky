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
        }
    }
	private void WarriorAttack(Transform player)
	{
		Vector3 direction = player.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (direction);
		Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, 3f* Time.deltaTime).eulerAngles;
		transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        var obj = _ammoControl.Pull();
        var objTR = obj.GetComponent<Transform>();

        objTR.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
       
        objTR.transform.position = Vector3.MoveTowards(transform.position, player.position, 5f * Time.deltaTime);
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
