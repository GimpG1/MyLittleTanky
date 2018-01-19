using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFUEL : MonoBehaviour {
    private float _fuel;

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
}
