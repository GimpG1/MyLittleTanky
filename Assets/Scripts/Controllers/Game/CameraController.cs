using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    #region Private Variables
    [SerializeField] AudioClip[] backgroundSounds;
	private AudioSource _source;
    private int _playSoundAt = 0;
    private bool _isPlayingActually = false;
    #endregion

	private void Start ()
    {
		_source = gameObject.GetComponent<AudioSource> ();
		_source.Stop ();
        _playSoundAt = Random.Range(0, 5);
        ChangeBackGroundSound(_playSoundAt);
    }

	private void Update()
	{
        if (!_source.isPlaying)
        {
            this._isPlayingActually = true;
        }
        if (_isPlayingActually)
        {
            _playSoundAt = Random.Range(0, 5);
            ChangeBackGroundSound(_playSoundAt);
            this._isPlayingActually = false;
        }
	}

	public void ChangeBackGroundSound(int soundIndex)
	{
		_source.clip = backgroundSounds[soundIndex];
		_source.Play ();
	}
}
