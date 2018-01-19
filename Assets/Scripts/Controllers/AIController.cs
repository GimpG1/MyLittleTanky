using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
#region Private Variables
    bool _attack = false;
    [SerializeField] Transform _playerTransform;
    private Vector3 _aiDefaultPos;
#endregion
    private void Awake()
    {
        _aiDefaultPos = transform.position;
    }

    private void Update()
    {
        if (_attack)
        {
            transform.position = transform.position - _playerTransform.transform.position;
        }
        else if (!_attack)
        {
            transform.position = _aiDefaultPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this._attack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this._attack = false;
        }
    }
}
