using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertEnter : MonoBehaviour
{
    [SerializeField] SoundAreasController _soundCntrl;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _soundCntrl.SwitchArea(1);
        }
    }
}
