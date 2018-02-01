using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour 
{
	private Vector3 pos;

	private void Update()
	{
		pos = Input.mousePosition;
		transform.position = pos;
	}

	public Transform GetMouseTransform()
	{
		return gameObject.transform.position;
	}
}
