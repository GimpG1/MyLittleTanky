using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
#region Private Variables
    [SerializeField] GameObject _MyHero;
    private float _cameraUpDistance = 8f;
    private float _cameraAwayDistance = 15f;
	[SerializeField] AudioClip[] backgroundSounds;
	private AudioSource _source;

	private float camXpos;
	private float camYpos;
	private float camZpos;
    #endregion
	private void Start ()
    {
        if (_MyHero == null)
        {
			_MyHero = GameObject.FindWithTag("Player");
        }
		_source = gameObject.GetComponent<AudioSource> ();
		_source.Stop ();
    }

	private void Update ()
    {
		camXpos = _MyHero.transform.position.x;
		camYpos = _MyHero.transform.position.y + _cameraUpDistance;
		camZpos = _MyHero.transform.position.z - _cameraAwayDistance;
		
        transform.LookAt(_MyHero.GetComponent<Transform>());
		Vector3 endPos = new Vector3 (camXpos,camYpos,camZpos);
		transform.position = endPos;
    }

	public void ChangeGroundSound(int soundIndex)
	{
		_source.clip = backgroundSounds[soundIndex];
		_source.Play ();
	}
}
