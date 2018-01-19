using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
#region Private Variables
    [SerializeField] GameObject _MyHero;
    // Less smooth is better
    private float _smoothCamera = .5f;
    private float _cameraUpDistance = 3f;
    private float _cameraAwayDistance = 8f;
    private Vector3 offset;
#endregion
    void Start ()
    {
        if (_MyHero == null)
        {
            Debug.LogError("There is no connected game object\nTrying to get it via script");
            try
            {
                _MyHero = GameObject.FindWithTag("Player");
            }
            catch (System.Exception e)
            {
                Debug.Log("Get game object via script failed.");
            }
        }
    }

	void LateUpdate ()
    {
        transform.LookAt(_MyHero.GetComponent<Transform>());
        Vector3 desPoint = _MyHero.transform.position + _MyHero.transform.up * _cameraUpDistance - _MyHero.transform.forward * _cameraAwayDistance;
        Vector3 endPosition = Vector3.Lerp(transform.position, desPoint, Time.deltaTime * _smoothCamera);
        transform.position = endPosition;
    }
}
