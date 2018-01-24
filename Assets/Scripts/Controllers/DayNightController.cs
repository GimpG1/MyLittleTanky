using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour {
    private Vector3 _centerScene = new Vector3(250f, 0f, 250f);


    void Update ()
    {
        transform.RotateAround(_centerScene,Vector3.left, 4*Time.deltaTime);
        transform.LookAt(_centerScene);
	}
}
