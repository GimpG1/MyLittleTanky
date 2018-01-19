using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHP : MonoBehaviour {
    private float _hp;

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
}
