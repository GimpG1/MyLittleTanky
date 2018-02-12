using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    private Vector3 _centerScene = new Vector3(250f, 0f, 250f);
    private float _rotateSpeed = 6f;
    [SerializeField] SoundAreasController _soundCntrl;

    void Update()
    {
        transform.RotateAround(_centerScene, Vector3.right, _rotateSpeed * Time.deltaTime);
        transform.LookAt(_centerScene);
        if (transform.position.y > 50f)
        {
            _rotateSpeed = 1f;
            _soundCntrl.SetDayTime = 1;
        }
        else
        {
            _rotateSpeed = 6f;
            _soundCntrl.SetDayTime = 2;
        }
    }
}
