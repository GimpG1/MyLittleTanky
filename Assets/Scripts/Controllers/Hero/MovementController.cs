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

    private bool _hasFuel = true;
	private bool _startEngine = false;
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
        if (Input.GetKeyDown(KeyCode.X) && !_startEngine)
        {
            _heroStats.IsEngineWork = true;
			this._startEngine = true;
        }
		else if (Input.GetKeyDown(KeyCode.X) && _startEngine)
		{
			_heroStats.IsEngineWork = false;
			this._startEngine = false;
		}
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }
		if (Input.GetKeyDown(KeyCode.Escape) && _startEngine)
        {
            _inGameMenu.OnEscape();
			_heroStats.IsEngineWork = false;
			this._startEngine = false;
        }
		else if (Input.GetKeyDown(KeyCode.Escape) && !_startEngine) 
		{
			_heroStats.IsEngineWork = false;
			this._startEngine = false;
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
