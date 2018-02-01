using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour 
{
	private bool _playerDetected = false;
	[SerializeField] private Transform _playerTransform;

	private void Update()
	{
		transform.LookAt(_playerTransform);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			HeroTransform = other.GetComponent<Transform> ();
			this._playerDetected = true;
		}
	}

	private void OnTriggerLeave(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			this._playerDetected = false;
		}
	}
	public bool IsDetected
	{
		get
		{
			return _playerDetected;
		}
	}

	public Transform HeroTransform
	{
		get
		{ 
			return _playerTransform;
		}
		private set
		{ 
			if (_playerTransform == null)
			{
				_playerTransform = GameObject.Find("Tanky").GetComponent<Transform>();
			}
		}
	}
}
