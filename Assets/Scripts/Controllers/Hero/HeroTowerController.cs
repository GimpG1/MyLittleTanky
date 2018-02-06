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
	}
    public void UserSetTowerAngle(float angle)
    {
        GetSetTowerAngle = angle;
    }
    public void UserSetAimAngle(float angle)
    {
        GetSetAimAngle = Mathf.Clamp(angle, -7f, 7f);
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