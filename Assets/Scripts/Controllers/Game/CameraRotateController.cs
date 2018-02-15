using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateController : MonoBehaviour
{
    [SerializeField] Transform _lookAtTower;
    [SerializeField] Transform _hero;
    [SerializeField] HeroTowerController _towerController;
    private float _camDistFromTarget;

	public void RotateCamera ()
    {
        _camDistFromTarget = Vector3.Distance(transform.position, _hero.transform.position);

        transform.RotateAround(_lookAtTower.transform.position,
                                Vector3.up,
                                _towerController.GetSetTowerAngle * _camDistFromTarget);
    }
}
