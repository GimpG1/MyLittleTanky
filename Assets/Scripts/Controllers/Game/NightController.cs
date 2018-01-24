using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightController : MonoBehaviour
{
    private Vector3 _centerScene = new Vector3(250f, 0f, 250f);
    private float _rotateSpeed = 1f;

    void Update()
    {
        transform.RotateAround(_centerScene, Vector3.right, _rotateSpeed * Time.deltaTime);
        transform.LookAt(_centerScene);
        if (transform.position.y > 50f)
        {
            _rotateSpeed = 7f;
        }
        else
            _rotateSpeed = 1f;
    }
}
