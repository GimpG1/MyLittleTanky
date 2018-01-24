using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
#region Private Variables
    bool _attack = false;
    [SerializeField] Transform _playerTransform;
#endregion

    private void Update()
    {
        if (_attack)
        {
            transform.LookAt(_playerTransform);
            transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position,1f);
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
