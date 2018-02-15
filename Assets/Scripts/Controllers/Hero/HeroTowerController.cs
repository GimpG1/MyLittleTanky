using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTowerController : MonoBehaviour 
{
	[SerializeField] Transform _tankAim;
	[SerializeField] Transform _tankTower;
	[SerializeField] Transform _tank;

	private float _rotateSpeed = .5f;
	private float _aimSpeed = 2f;
    
	private float towerZAngle;
    private float aimYAngle;
    private float maxYAimAngle = -90f;
    private float minYAimAngle = -102f;
	private Vector3 _towerDefaultRotate;

	private void Update()
	{
		
		_towerDefaultRotate = new Vector3(-90f, 0f, 90f);
        towerZAngle += GetSetTowerAngle * _rotateSpeed * Time.deltaTime;
        _tankTower.transform.RotateAroundLocal(Vector3.up, towerZAngle);
        aimYAngle += GetSetAimAngle / _aimSpeed * Time.deltaTime;
        if (_tankAim.transform.rotation.y >= maxYAimAngle || _tankAim.transform.rotation.y <= minYAimAngle)
        {
            _tankAim.transform.RotateAroundLocal(Vector3.up, aimYAngle);
        }
	}
    public void UserSetTowerAngle(float angle)
    {
        GetSetTowerAngle = angle;
    }
    public void UserSetAimAngle(float angle)
    {
        GetSetAimAngle = Mathf.Clamp(angle, -.5f, .5f);
    }
	public float GetSetTowerAngle
	{
		get
		{
			return towerZAngle; 
		}
		private set 
		{
			towerZAngle = value;
		} 
	}
    public float GetSetAimAngle
    {
        get
        {
            return aimYAngle;
        }
        private set
        {
            aimYAngle = value;
        }
    }
}