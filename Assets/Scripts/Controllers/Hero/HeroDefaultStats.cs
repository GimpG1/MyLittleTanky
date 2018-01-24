using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDefaultStats : MonoBehaviour
{
    public int _startHP = 100;
    public int _startFUEL = 100;
    public int _startAMMUNATION = 100;
    // Its own
    public int _attactPower = 5;

    public void TakeDamage(int damage)
    {
        _startHP -= damage;
    }
}
