using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OazaSounds : MonoBehaviour
{
    [SerializeField] SoundAreasController _soundCntrl;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _soundCntrl.SetSoundArea = 3;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _soundCntrl.SetSoundArea = 1;
        }
    }
}
