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
	[SerializeField] EndGameController _endGame;

	[SerializeField] private AudioSource _tankMoveSound;
    private bool _startEngine = false;
    #endregion

    private void Awake()
    {
		if (_tankHp == null ||
			_tankFuel == null ||
			_tankAmmo == null ||
			_tankMainPower == null ||
			_endGame == null) 
		{
			_tankHp = gameObject.GetComponent<ObjectsHP> ();
			_tankFuel = gameObject.GetComponent<ObjectsFUEL> ();
			_tankAmmo = gameObject.GetComponent<ObjectsAMMUNATION> ();
			_tankMainPower = gameObject.GetComponent<ObjectsAttackPOWER> ();
			_isDamaged = gameObject.GetComponent<DamagedController> ();
			_endGame = gameObject.GetComponent<EndGameController> ();

			_tankHp.SetGetHp = 1000;
			_tankFuel.SetGetFuel = 20;
			_tankAmmo.SetGetAmmunation = 5;
			_tankMainPower.SetGetAttackPower = 50;
		}
    }

	private void Update()
    {
        if (IsEngineWork)
        {
            LoseFuel(_tankFuel.SetGetFuel);
			PlayMovementSound (IsEngineWork);
        }
		SetDamaged (_tankHp.SetGetHp);
		if (_tankHp.SetGetHp <= 0) 
		{
			_endGame.ShowEndMessage ();
			gameObject.SetActive (false);
		} 
		else if (_tankFuel.SetGetFuel <= 0f) 
		{
			_endGame.ShowEndMessage ();
		}
    }
	private void PlayMovementSound(bool play)
	{
		if (play) 
		{
			_tankMoveSound.clip = gameObject.GetComponent<AudioClip> ();
			_tankMoveSound.Play ();
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
