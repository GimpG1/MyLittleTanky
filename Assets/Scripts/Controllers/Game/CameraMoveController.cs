using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    [SerializeField] Transform _hero;
    private Vector3 _camStartPos;
    private float _camUpDist = 3f;
    private float _camBackDist = 10f;
    private float _camDistFromTarget = 0f;

    private void Update()
    {
        _camDistFromTarget = Vector3.Distance(transform.position, _hero.transform.position);

        transform.LookAt(_hero);
        Vector3 endPos = new Vector3(_hero.transform.position.x,
                                      _hero.transform.position.y + _camUpDist,
                                      _hero.transform.position.z - _camBackDist);
        transform.position = endPos;
    }

}
