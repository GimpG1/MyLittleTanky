using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] GameObject _MyHero;
    
    private Vector3 offset;

    void Start ()
    {
        if (_MyHero == null)
        {
            Debug.LogError("There is no connected game object");
        }
        offset = transform.position - _MyHero.transform.position;
    }

	void LateUpdate ()
    {
        transform.LookAt(_MyHero.GetComponent<Transform>());
        Vector3 desPoint = _MyHero.transform.position + offset;
        Vector3 endPosition = Vector3.Lerp(transform.position, desPoint, Time.deltaTime * 1f);
        transform.position = endPosition;
    }
}
