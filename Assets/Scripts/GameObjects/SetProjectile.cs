using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetProjectile : MonoBehaviour 
{
	// My ammunation
	[SerializeField] private ObjectsAttackPOWER _ammoPower;
	[SerializeField] private ProjectileHandler _projectileHand;
	[SerializeField] private HeroStats _hero;
	private float _lifeTime = 2f;
	private bool _targetReached = true;
	 
	private void Awake() 
	{
		_ammoPower = gameObject.GetComponent<ObjectsAttackPOWER>();
		_projectileHand = GameObject.Find ("ProjectileHandler").GetComponent<ProjectileHandler> ();
		_hero = GameObject.Find("Tanky").GetComponent<HeroStats>();
		_ammoPower.SetGetAttackPower = 20;
	}

	private void Update()
    {
		if (_targetReached == false)
        {
            _lifeTime -= Time.deltaTime;
            if (_lifeTime < 1f)
            {
                _projectileHand.Push(gameObject);
            }
        }
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            _hero.TakeDamage(_ammoPower.SetGetAttackPower);
            _projectileHand.Push(gameObject);
        }
		else  
		{
			this._targetReached = false;
		}
            
	}
}
