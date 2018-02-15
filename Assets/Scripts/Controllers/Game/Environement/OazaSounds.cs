using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OazaSounds : MonoBehaviour
{
    [SerializeField] SoundAreasController _soundCntrl;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _soundCntrl.SwitchArea(3, true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _soundCntrl.SwitchArea(1, true);
        }
    }
}
