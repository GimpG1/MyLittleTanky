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

    private int _soundArea = 4;
    private int _dayTime;

    private void LateUpdate()
    {
        SwitchArea(SetSoundArea, SetDayTime);
    }

    private void SwitchArea(int area, int daytime)
    {
        if (area == (int)SoundArea.Base)
        {
            // el 0 base
            mixerSnapshot[0].TransitionTo(1);
            _myCamAudio.ChangeBackGroundSounds(SetSoundArea, SetDayTime);
            
        }
        if (area == (int)SoundArea.Desert)
        {
            // el 1 desert
            mixerSnapshot[1].TransitionTo(1);
            _myCamAudio.ChangeBackGroundSounds(SetSoundArea, SetDayTime);
        }
        if (area == (int)SoundArea.Forest)
        {
            // el 2 forest
            mixerSnapshot[2].TransitionTo(1);
            _myCamAudio.ChangeBackGroundSounds(SetSoundArea, SetDayTime);
        }
        if (area == (int)SoundArea.Oaza)
        {
            // el 3 oaza
            mixerSnapshot[3].TransitionTo(1);
            _myCamAudio.ChangeBackGroundSounds(SetSoundArea, SetDayTime);
        }
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

}
