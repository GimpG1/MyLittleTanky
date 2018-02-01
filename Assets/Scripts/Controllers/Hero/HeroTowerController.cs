using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTowerController : MonoBehaviour 
{
	[SerializeField] Transform _tankAim;
	[SerializeField] Transform _tankTower;
	[SerializeField] MousePosition _mousePos;

	private float _rotateSpeed = 15f;
	private float _aimSpeed = 5f;
	private Transform _mouse;

	private void Update()
	{
		_mouse = _mousePos.GetMouseTransform;
		Vector3 direction = _mouse.transform.position - _tankTower.transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (direction);
		Vector3 rotation = Quaternion.Lerp (_tankTower.transform.rotation, lookRotation, 3f * Time.deltaTime).eulerAngles;
		_tankTower.transform.rotation = Quaternion.Euler (0f, rotation.y, 0f);

	}
}
