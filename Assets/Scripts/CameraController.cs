using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _MyHero;
    
    private Vector3 offset;

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
        Vector3 desPoint = _MyHero.transform.position + _MyHero.transform.up * 3f - _MyHero.transform.forward * 8f;
        Vector3 endPosition = Vector3.Lerp(transform.position, desPoint, Time.deltaTime * 1f);
        transform.position = endPosition;
    }
}
