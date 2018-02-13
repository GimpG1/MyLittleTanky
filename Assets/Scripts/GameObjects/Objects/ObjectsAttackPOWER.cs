using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsAttackPOWER : MonoBehaviour {
    private int _attackPower;

    public int SetGetAttackPower
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
