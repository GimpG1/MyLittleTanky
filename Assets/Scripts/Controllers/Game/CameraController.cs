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
    private int _trackToPlay;
   // private bool _isPlayingActually = false;
    #endregion

	private void Start ()
    {
		_source = gameObject.GetComponent<AudioSource> ();
		_source.Stop ();
    }

    private void Update()
	{
        SetTrack = _soundAreas.GetSoundIndexToPlay;
        if (!_source.isPlaying)
        {
            _changeBackGroundSound(_trackToPlay);
        }
        if (_source.isPlaying)
        {
            _changeBackGroundSound(_trackToPlay);
        }
	}

	public void _changeBackGroundSound(int soundIndex)
	{
		_source.clip = _baseBackgroundSounds[soundIndex];
		_source.Play ();
	}
    public int SetTrack
    {
        get { return _trackToPlay; }
        private set { _trackToPlay = value; }
    }
}
