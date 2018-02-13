using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CameraController : MonoBehaviour
{
    #region Private Variables
    [SerializeField] AudioClip[] _baseBackgroundSounds;
    [SerializeField] SoundAreasController _soundAreas;
    private AudioSource _source;
   
    private bool _isPlayingActually = false;
    private bool _changeTrack;
    #endregion

	private void Start ()
    {
		_source = gameObject.GetComponent<AudioSource> ();
		_source.Stop ();
    }

    private void Update()
	{
        
        SetChangeTrack = _soundAreas.AreaChanged();
        if (!_source.isPlaying && !_changeTrack)
        {
            this._isPlayingActually = true;
        }
        if (_isPlayingActually)
        {
            ChangeBackGroundSound(_soundAreas.GetSoundIndexToPlay());
            this._isPlayingActually = false;
        }
	}

	public void ChangeBackGroundSound(int soundIndex)
	{
		_source.clip = _baseBackgroundSounds[soundIndex];
		_source.Play ();
	}

    public bool SetChangeTrack
    {
        get { return _changeTrack; }
        private set { _changeTrack = value; }
    }
}
