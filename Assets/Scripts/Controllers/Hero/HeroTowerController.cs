using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HeroTowerController : MonoBehaviour 
{
	[SerializeField] Transform _tankAim;
	[SerializeField] Transform _tankTower;
	[SerializeField] Transform _tank;

	private float _rotateSpeed = 5f;
	private float _aimSpeed = 2f;

	//private float minAimAngle = -105f;
	//private float maxAimAngle = -70f;

	private float towerZAngle;
    private float aimYAngle;
	private float zAxis = -90f;
	private Vector3 _towerDefaultRotate;

	private void Update()
	{
		
		_towerDefaultRotate = new Vector3(-90f, 0f, 90f);
        towerZAngle += GetSetTowerAngle / _rotateSpeed * Time.deltaTime;
        _tankTower.transform.RotateAroundLocal(Vector3.up, towerZAngle);
        aimYAngle += GetSetAimAngle / _aimSpeed * Time.deltaTime;
        _tankAim.transform.RotateAroundLocal(Vector3.up, aimYAngle);
        
        /*
		float towerZRotation = _tankTower.transform.rotation.z /Time.deltaTime;
		GetSetTowerAngle = zAxis + _tankTower.transform.rotation.z;
        */
	}
    public void UserSetTowerAngle(float angle)
    {
        GetSetTowerAngle = angle;
    }
    public void UserSetAimAngle(float angle)
    {
        GetSetAimAngle = Mathf.Clamp(angle,-12f,12f);
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