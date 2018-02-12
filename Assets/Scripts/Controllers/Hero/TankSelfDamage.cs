using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelfDamage : MonoBehaviour
{
    [SerializeField] private HeroStats _heroStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            _heroStats.TakeDamage(20);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            _heroStats.TakeDamage(30);
        }
    }
}
