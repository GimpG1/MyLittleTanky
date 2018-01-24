using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Tank base speed
    private float _tankSpeed = 10f;
    private InGameGUIController _inGameMenu;
    private void Awake()
    {
        _inGameMenu = GameObject.Find("InGameCanvas").GetComponent<InGameGUIController>();
    }
    private void Update()
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
            transform.Rotate(Vector3.down);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _inGameMenu.OnEscape();
        }
    }
}
