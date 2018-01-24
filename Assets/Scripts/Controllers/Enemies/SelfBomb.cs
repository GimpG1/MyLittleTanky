using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBomb : MonoBehaviour
{
    #region Private Variables
    bool _attack = false;
    float _speed = 5f;
    [SerializeField] private Transform _playerTransform;
    HeroDefaultStats hero;
    #endregion

    private void Update()
    {
        if (_attack)
        {
            transform.LookAt(_playerTransform);
            transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_playerTransform == null)
            {
                _playerTransform = other.gameObject.GetComponent<Transform>();
                hero = other.gameObject.GetComponent<HeroDefaultStats>();
            }
            this._attack = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            hero.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
