using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour 
{
	[SerializeField] private GameObject _ammoPrefab;
	List<GameObject> _poolHandle = new List<GameObject>();

	private void Awake()
	{
		if (_ammoPrefab == null) 
		{
			_ammoPrefab = Resources.Load ("Amunation") as GameObject;
		}
	}
	// zabierz
	public GameObject Pull()
	{
		var inPool = _poolHandle.FirstOrDefault ();
		if (inPool != null) 
		{
			_poolHandle.Remove (inPool);
			inPool.SetActive (true);
			return inPool;
		}
		inPool = Instantiate (_ammoPrefab);
		return inPool;
	}
	// oddaj
	public void Push(GameObject toPool)
	{
		toPool.SetActive(false);
		_poolHandle.Add (toPool);
	}
}
