using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsAttackPOWER : MonoBehaviour {
    private float _attackPower;

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
}
