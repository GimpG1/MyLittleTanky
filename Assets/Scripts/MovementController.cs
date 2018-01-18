using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    private float _tankSpeed = 10f;
	
	void Start ()
    {
		
	}
	
	
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _tankSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * _tankSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up);
        }
    }
}
