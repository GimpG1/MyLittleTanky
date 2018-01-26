using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetProjectile : MonoBehaviour 
{
	[SerializeField] private ObjectsAttackPOWER _ammoPower;
	[SerializeField] private ProjectileHandler _projectileHand;
	[SerializeField] private HeroStats _hero;
	[SerializeField] private float _lifeTime = 2f;
	 
	private void Awake() 
	{
		_ammoPower = gameObject.GetComponent<ObjectsAttackPOWER>();
		_projectileHand = GameObject.Find ("ProjectileHandler").GetComponent<ProjectileHandler> ();
		_hero = GameObject.Find("HeroTank").GetComponent<HeroStats>();
		_ammoPower.SetGetAttackPower = 20;
	}

	private void Update()
	{
		_lifeTime -= Time.deltaTime;
		if (_lifeTime <= 0.0f)
		{
			_projectileHand.Push (gameObject);
			Destroy (gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.CompareTag("Terrain") && collision.gameObject.CompareTag("Player"))
		{
			_hero.TakeDamage (_ammoPower.SetGetAttackPower);
			_projectileHand.Push (gameObject);
			Destroy (gameObject);
		}
	}
}
