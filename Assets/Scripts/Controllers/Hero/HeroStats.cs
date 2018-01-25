using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
	[SerializeField] ObjectsHP _tankHp;
	[SerializeField] ObjectsFUEL _tankFuel;
	[SerializeField] ObjectsAMMUNATION _tankAmmo;
	[SerializeField] ObjectsAttackPOWER _tankMainPower;
	public float _itsPosition;
    bool _isMoving = false;

    void Awake()
    {
		if (_tankHp == null ||
			_tankFuel == null ||
			_tankAmmo == null ||
			_tankMainPower == null) 
		{
			_tankHp = gameObject.GetComponent<ObjectsHP> ();
			_tankFuel = gameObject.GetComponent<ObjectsFUEL> ();
			_tankAmmo = gameObject.GetComponent<ObjectsAMMUNATION> ();
			_tankMainPower = gameObject.GetComponent<ObjectsAttackPOWER> ();

			_tankHp.SetGetHp = 100;
			_tankFuel.SetGetFuel = 1000;
			_tankAmmo.SetGetAmmunation = 5;
			_tankMainPower.SetGetAttackPower = 50;
		}
    }

	void Start()
	{
		_itsPosition = transform.position.x;
	}

    void Update()
    {
		if (_itsPosition > transform.position.x || _itsPosition < transform.position.x) {
			_isMoving = true;
		} 
		else
			_isMoving = false;
		
        if (_isMoving)
        {
            LoseFuel(_tankFuel.SetGetFuel);
        }
    }

    public void TakeDamage(int damage)
    {
        _tankHp.SetGetHp -= damage;
    }

    private void LoseFuel(int fuel)
    {
		if (_tankFuel.SetGetFuel > 0f) 
		{
			_tankFuel.SetGetFuel--;
		}
    }
}
