using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBomb : MonoBehaviour
{
    #region Private Variables
    bool _attack = false;
    [SerializeField] private Transform _playerTransform;
    #endregion

    private void Update()
    {
        if (_attack)
        {
            transform.LookAt(_playerTransform);
            transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, 1f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_playerTransform == null)
            {
                _playerTransform = other.gameObject.GetComponent<Transform>();
            }
            this._attack = true;
        }
    }
}
