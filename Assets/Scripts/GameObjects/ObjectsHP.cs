using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHP : MonoBehaviour
{
    private int _hp;

    public int SetGetHp
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
