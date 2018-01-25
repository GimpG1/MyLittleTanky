using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour 
{
	#region Private Variables
	[SerializeField] HeroStats hero;
	[SerializeField] DetectPlayer detector;
	[SerializeField] ObjectsHP hp;
	[SerializeField] ObjectsAttackPOWER power;
	[SerializeField] BonusController defeatBonus;
	#endregion

	private void Awake()
	{
		if (hero == null)
		{
			hero = GameObject.Find("HeroTank").GetComponent<HeroStats>();
		}
		if (hp == null) 
		{
			hp = gameObject.GetComponent<ObjectsHP> ();
			hp.SetGetHp = 300;
		}
		if (power == null) 
		{
			power = gameObject.GetComponent<ObjectsAttackPOWER> ();
			power.SetGetAttackPower = 10;
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

	private void Update()
	{
		if (detector.IsDetected)
		{
			TurrentAttack (detector.HeroTransform);
		}
	}

	private void TurrentAttack(Transform player)
	{
		Vector3 direction = player.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (direction);
		transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 2f* Time.deltaTime);
	}
}
