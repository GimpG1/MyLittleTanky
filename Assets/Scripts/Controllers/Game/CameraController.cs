using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CameraController : MonoBehaviour
{
    #region Private Variables
    [SerializeField] AudioClip[] _baseBackgroundSounds;
    [SerializeField] AudioClip _oazaSound;
    [SerializeField] AudioClip[] _desertSounds;
    [SerializeField] AudioClip[] _forestSounds;
    [SerializeField] SoundAreasController _soundCntrl;
    private AudioSource _source;
   
    private int _playSoundAt = 0;
    private bool _isPlayingActually = false;
    #endregion

	private void Start ()
    {
		_source = gameObject.GetComponent<AudioSource> ();
		_source.Stop ();
        _playSoundAt = Random.Range(0, 4);
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
            _playSoundAt = Random.Range(0, 4);
            ChangeBackGroundSound(_playSoundAt);
            this._isPlayingActually = false;
        }
	}

	public void ChangeBackGroundSound(int soundIndex)
	{
		_source.clip = _baseBackgroundSounds[soundIndex];
		_source.Play ();
	}
    public void ChangeBackGroundSounds(int area, int daytime)
    {
        if (area == 0 && daytime == 1)
        {
            _playSoundAt = Random.Range(0, 4);
            ChangeBackGroundSound(_playSoundAt);
        }
        if (area == 1 && daytime == 1)
        {
            _source.clip = _desertSounds[0];
            _source.Play();
        }
        if (area == 2 && daytime == 1)
        {
            _source.clip = _forestSounds[0];
            _source.Play();
        }
        if (area == 3 && daytime == 1)
        {
            _source.clip = _oazaSound;
            _source.Play();
        }
        if (area == 0 && daytime == 2)
        {
            _playSoundAt = Random.Range(0, 5);
            ChangeBackGroundSound(_playSoundAt);
        }
        if (area == 1 && daytime == 2)
        {
            _source.clip = _desertSounds[1];
            _source.Play();
        }
        if (area == 2 && daytime == 2)
        {
            _source.clip = _forestSounds[1];
            _source.Play();
        }
        if (area == 3 && daytime == 2)
        {
            _source.clip = _oazaSound;
            _source.Play();
        }
    }
}
