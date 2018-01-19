using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Tank base speed
    private float _tankSpeed = 10f;
    public Texture2D _tankDative;

    private void Awake()
    {
        Cursor.visible = true;
        Cursor.SetCursor(_tankDative, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void FixedUpdate()
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
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Fire !");
        }
    }
}
