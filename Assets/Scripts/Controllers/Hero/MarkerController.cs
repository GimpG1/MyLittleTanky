using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[ExecuteInEditMode]
public class MarkerController : MonoBehaviour
{
    #region variables
    [SerializeField] private Ray _aimTarget;
    [SerializeField] private GameObject _aim;

    [SerializeField] private AudioClip _shootClip;
    private float _aimTargetMaxDistance = 50;
    #endregion
    private void FixedUpdate ()
    {
        _aimTarget = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(_aimTarget, out hit, _aimTargetMaxDistance))
        {
           
        }
	}
    public void PlayShootSound()
    {
        var aSource = gameObject.GetComponent<AudioSource>();
        
        if (!aSource.isPlaying || aSource.isPlaying)
        {
            aSource.clip = _shootClip;
            aSource.Play();
        }
    }
}
