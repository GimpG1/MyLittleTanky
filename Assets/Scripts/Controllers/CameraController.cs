using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
#region Private Variables
    [SerializeField] GameObject _MyHero;
    // Less smooth is better
    //private float _smoothCamera = 1f;
    private float _cameraUpDistance = 8f;
    private float _cameraAwayDistance = 15f;

	private float camXpos;
	private float camYpos;
	private float camZpos;
    #endregion
    void Start ()
    {
        if (_MyHero == null)
        {
			_MyHero = GameObject.FindWithTag("Player");
        }

    }

	void Update ()
    {
		camXpos = _MyHero.transform.position.x;
		camYpos = _MyHero.transform.position.y + _cameraUpDistance;
		camZpos = _MyHero.transform.position.z - _cameraAwayDistance;
		
        transform.LookAt(_MyHero.GetComponent<Transform>());
		Vector3 endPos = new Vector3 (camXpos,camYpos,camZpos);
		transform.position = endPos;
		/*
		Vector3 desPoint = _MyHero.transform.position + _MyHero.transform.up * _cameraUpDistance - _MyHero.transform.forward * _cameraAwayDistance * Time.deltaTime;
		Vector3 endPosition = Vector3.Lerp(transform.position, desPoint, _smoothCamera * Time.deltaTime );
		transform.position = endPosition;
		*/
    }
}
