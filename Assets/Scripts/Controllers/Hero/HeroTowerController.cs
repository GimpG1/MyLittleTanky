using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HeroTowerController : MonoBehaviour 
{
	[SerializeField] Transform _tankAim;
	[SerializeField] Transform _tankTower;
	[SerializeField] Transform _tank;

	//private float _rotateSpeed = 15f;
	//private float _aimSpeed = 5f;

	//private float minAimAngle = -105f;
	//private float maxAimAngle = -70f;

	private Vector3 _towerDefaultRotate;

	private void Update()
	{
		_towerDefaultRotate = new Vector3(-90f, 0f, 90f);

		float towerZRotation = _tankTower.transform.rotation.z *Time.deltaTime;

	}
