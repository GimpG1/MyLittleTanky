using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    #region Variables
    [SerializeField] ObjectsHP _tankHp;
	[SerializeField] ObjectsFUEL _tankFuel;
	[SerializeField] ObjectsAMMUNATION _tankAmmo;
	[SerializeField] ObjectsAttackPOWER _tankMainPower;
	[SerializeField] DamagedController _isDamaged;
    private bool _startEngine = false;
    #endregion

    private void Awake()
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
			_isDamaged = gameObject.GetComponent<DamagedController> ();

			_tankHp.SetGetHp = 1000;
			_tankFuel.SetGetFuel = 1000;
			_tankAmmo.SetGetAmmunation = 5;
			_tankMainPower.SetGetAttackPower = 50;
		}
    }

	private void Start()
	{
		//_itsPosition = transform.position.x;
	}

	private void Update()
    {
        if (IsEngineWork)
        {
            LoseFuel(_tankFuel.SetGetFuel);
        }
		SetDamaged (_tankHp.SetGetHp);
		if (_tankHp.SetGetHp <= 0) 
		{
			gameObject.SetActive (false);
		}
    }

	private void LoseFuel(int fuel)
	{
		if (_tankFuel.SetGetFuel > 0f) 
		{
			_tankFuel.SetGetFuel--;
		}
	}

	private void SetDamaged (int hp)
	{
		if (hp < _tankHp.SetGetHp) 
		{
			_isDamaged.SetGetDamaged = false;
		}
		else
			_isDamaged.SetGetDamaged = true;
	}
    public void TakeDamage(int damage)
    {
		_tankHp.SetGetHp -= damage;
    }

	public bool IsEngineWork
	{
		get
		{
			return _startEngine;
		}
		set
		{
            _startEngine = value;
		}
	}
}
