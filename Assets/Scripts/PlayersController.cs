using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
#region Private Variables
    private float _hp;
    private float _fuel;
    private float _attackPower;
    private float _ammunation;
    #endregion
#region Accesors
    public float SetGetHp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }
    public float SetGetFuel
    {
        get
        {
            return _fuel;
        }
        set
        {
            _fuel = value;
        }
    }
    public float SetGetAttackPower
    {
        get
        {
            return _attackPower;
        }
        set
        {
            _attackPower = value;
        }
    }
    public float SetGetAmmunation
    {
        get
        {
            return _ammunation;
        }
        set
        {
            _ammunation = value;
        }
    }
#endregion
}
