using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundAreasController : MonoBehaviour
{
    [SerializeField] CameraController _myCamAudio;
    [SerializeField] AudioMixerSnapshot[] mixerSnapshot;

    enum SoundArea
    {
        Base = 0,
        Desert = 1,
        Forest = 2,
        Oaza = 3
    }
    
    private int _dayTime;
    private int _playSoundIndex;
    private bool _isRandomized;
    private bool _change;

    private void Update()
    {
       // Debug.Log(_playSoundIndex.ToString() + " sound areacontroller");
    }
    public void SwitchArea(int area, bool change)
    {
        Debug.Log("inside switch " + _playSoundIndex.ToString());
        _change = change;
        if (area == (int)SoundArea.Base && _change == true)
        {
            // el 0 base
           // Debug.Log("inside base " + _playSoundIndex.ToString());
            this._isRandomized = false;
            mixerSnapshot[0].TransitionTo(1);
            if (!_isRandomized)
            {
                this._playSoundIndex = Random.Range(0, 4);
                this._isRandomized = true;
               // Debug.Log("randomized " + _playSoundIndex.ToString());
            }
            _change = false;
        }
        if (area == (int)SoundArea.Desert && _change)
        {
            // el 1 desert
            mixerSnapshot[3].TransitionTo(1);
            this._playSoundIndex = 4;
        }
        if (area == (int)SoundArea.Desert && SetDayTime == 2)
        {
            this._playSoundIndex = 5;
        }
        if (area == (int)SoundArea.Forest && _change)
        {
            // el 2 forest
            mixerSnapshot[2].TransitionTo(1);
            this._playSoundIndex = 6;
        }
        if (area == (int)SoundArea.Forest && SetDayTime == 2)
        {
            this._playSoundIndex = 7;
        }
        if (area == (int)SoundArea.Oaza && _change)
        {
            // el 3 oaza
            mixerSnapshot[1].TransitionTo(1);
            this._playSoundIndex = 8;
        }
        _change = false;
    }
    public int SetDayTime
    {
        get
        {
            return _dayTime;
        }
        set
        {
            _dayTime = value;
        }
    }

    public int GetSoundIndexToPlay
    {
        get { return _playSoundIndex; }
    }
}
