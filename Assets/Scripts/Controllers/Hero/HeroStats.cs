using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    public int _startHP = 100;
    public float _startFUEL;
    public int _startAMMUNATION;
    // Its own
    public int _attactPower = 5;
	public float _itsPosition;
    bool _isMoving = false;

    void Awake()
    {
		SetFuel = 10;
		SetAmmo = 10;
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
            LoseFuel(SetFuel);
        }
    }

    public void TakeDamage(int damage)
    {
        _startHP -= damage;
    }

    private void LoseFuel(float fuel)
    {
		if (SetFuel > 0f) 
		{
			SetFuel -= Time.deltaTime;
		}
    }

    public float SetFuel
    {
        get
        {
            return _startFUEL;
        }
        set
        {
            _startFUEL = value;
        }
    }

	public int SetAmmo
	{
		get
		{
			return _startAMMUNATION;
		}
		set
		{
			_startAMMUNATION = value;
		}
	}
}
