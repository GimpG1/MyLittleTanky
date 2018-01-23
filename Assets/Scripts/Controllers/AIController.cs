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
            transform.LookAt(_playerTransform);
            transform.position = (_playerTransform.transform.position - transform.position).normalized;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this._attack = true;
        }
    }
}
