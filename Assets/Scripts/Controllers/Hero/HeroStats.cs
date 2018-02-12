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
    [SerializeField] private AudioClip _tankClip;
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

			_tankHp.SetGetHp = 5000;
			_tankFuel.SetGetFuel = 3000;
			_tankAmmo.SetGetAmmunation = 5;
			_tankMainPower.SetGetAttackPower = 50;
		}
    }
    private void Start()
    {
        _tankMoveSound = gameObject.GetComponent<AudioSource>();
        _tankMoveSound.Stop();
    }
    private void Update()
    {
        if (IsEngineWork)
        {
            LoseFuel(_tankFuel.SetGetFuel);
            PlayMovementSound();
        }
        else if (!IsEngineWork)
        {
            StopPlayingSound();
        }
        SetDamaged (_tankHp.SetGetHp);

		if (_tankHp.SetGetHp <= 1) 
		{
			_endGame.ShowEndMessage ();
			gameObject.SetActive (false);
            StopPlayingSound();
		} 
		else if (_tankFuel.SetGetFuel <= 0f) 
		{
			_endGame.ShowEndMessage ();
            StopPlayingSound();
        }
    }
    private void PlayMovementSound()
    {
        _tankMoveSound.clip = _tankClip;
        if (_tankMoveSound.isPlaying == false)
        {
            _tankMoveSound.Play();
        }
    }

    private void StopPlayingSound()
    {
        if (_tankMoveSound.isPlaying == true)
        {
            _tankMoveSound.Stop();
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
