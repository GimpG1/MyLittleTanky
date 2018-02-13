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

    private int _soundArea;
    private int _dayTime;
    private int _playSoundIndex;
    private bool _isRandomized;
    private bool _changed;
    
    public void SwitchArea(int area)
    {
        if (area == (int)SoundArea.Base)
        {
            // el 0 base
            this._isRandomized = false;
            mixerSnapshot[0].TransitionTo(1);
            if (!_isRandomized)
            {
                this._playSoundIndex = Random.Range(0, 4);
                this._isRandomized = true;
            }
            _changed = true;
        }
        if (area == (int)SoundArea.Desert)
        {
            // el 1 desert
            mixerSnapshot[3].TransitionTo(1);
            this._playSoundIndex = 4;
            _changed = true;
        }
        if (area == (int)SoundArea.Desert && SetDayTime == 2)
        {
            this._playSoundIndex = 5;
            _changed = true;
        }
        if (area == (int)SoundArea.Forest)
        {
            // el 2 forest
            mixerSnapshot[2].TransitionTo(1);
            this._playSoundIndex = 6;
            _changed = true;
        }
        if (area == (int)SoundArea.Forest && SetDayTime == 2)
        {
            this._playSoundIndex = 7;
            _changed = true;
        }
        if (area == (int)SoundArea.Oaza)
        {
            // el 3 oaza
            mixerSnapshot[1].TransitionTo(1);
            this._playSoundIndex = 8;
            _changed = true;
        }
        _changed = false;
    }
    public int SetSoundArea
    {
        get
        {
            return _soundArea;
        }
        set
        {
            _soundArea = value;
        }
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

    public int GetSoundIndexToPlay()
    {
        return _playSoundIndex;
    }

    public bool AreaChanged()
    {
        return _changed;
    }
}
