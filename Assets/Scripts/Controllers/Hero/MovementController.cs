using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
	#region Private Variables
    private float _tankSpeed = 10f;
    private float _tankRotationSpeed = 50f;
	[SerializeField] private InGameGUIController _inGameMenu;
	[SerializeField] private HeroStats _heroStats;
	[SerializeField] Transform _tankAim;
	[SerializeField] Transform _tankTower;
	private float mouseXPos;
	private float mouseYPos;

    private bool _hasFuel = true;
    private float _itsFuel;
	#endregion
    private void Awake()
    {
        _inGameMenu = GameObject.Find("InGameCanvas").GetComponent<InGameGUIController>();
        _heroStats = GameObject.Find("Tanky").GetComponent<HeroStats>();
        
    }

    private void Start()
    {
        _heroStats.IsEngineWork = false;
    }
    private void LateUpdate()
	{
		CheckFuel ();
	}

    private void Update()
    {
		mouseXPos = Input.mousePosition.x;
		mouseYPos = Input.mousePosition.y;

        if (_hasFuel == true && _heroStats.IsEngineWork == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * _tankSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * Time.deltaTime * _tankSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.down * Time.deltaTime * _tankRotationSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * Time.deltaTime * _tankRotationSpeed);
            }
        }
		if (mouseXPos >= 500) 
		{
			_tankTower.transform.Rotate (Vector3.forward * Time.deltaTime * _tankRotationSpeed);
		}

		if (mouseXPos <= 500) 
		{
			_tankTower.transform.Rotate (Vector3.back * Time.deltaTime * _tankRotationSpeed);
		}
		/*
		if(mouseYPos)
		{
			_tankAim.transform.Rotate (Vector3.left);
		}
		if(mouseYPos)
		{
			_tankAim.transform.Rotate (Vector3.right);
		}
		*/
        if (Input.GetKeyDown(KeyCode.X))
        {
            _heroStats.IsEngineWork = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _inGameMenu.OnEscape();
        }
    }

    private void CheckFuel()
    {
        _itsFuel = _heroStats.GetComponentInChildren<ObjectsFUEL>().SetGetFuel;
        if (_itsFuel > 0)
        {
            _hasFuel = true;
        }
        else if (_itsFuel < 1)
        {
            _hasFuel = false;
        }
    }

}
