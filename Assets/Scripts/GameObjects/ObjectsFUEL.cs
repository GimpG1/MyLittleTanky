using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFUEL : MonoBehaviour {
	private int _fuel;

    public int SetGetFuel
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
