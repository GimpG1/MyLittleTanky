using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAreasController : MonoBehaviour
{
    [SerializeField] CameraController _myCamAudio;

    enum SoundArea
    {
        Base = 0,
        Desert = 1,
        Forest = 2,
        Oaza = 3
    }

    enum DayTime
    {
        Day = 1,
        Night = 2
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
            Debug.Log("Base");
        }
        else if (area == (int)SoundArea.Desert)
        {
            Debug.Log("Desert");
        }
        else if (area == (int)SoundArea.Forest)
        {
            Debug.Log("Forest");
        }
        else if (area == (int)SoundArea.Oaza)
        {
            Debug.Log("Oaza");
        }

        if (daytime == (int)DayTime.Day)
        {
            Debug.Log("Day");
        }
        else if (daytime == (int)DayTime.Night)
        {
            Debug.Log("Night");
        }
    }
    public int SetSoundArea
    {
        private get
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
        private get
        {
            return _dayTime;
        }
        set
        {
            _dayTime = value;
        }
    }

}
