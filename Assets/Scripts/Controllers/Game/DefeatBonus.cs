using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefeatBonus : MonoBehaviour
{
    [SerializeField] private GameObject _bonus;
    List<GameObject> _bonuses = new List<GameObject>();
    private void Awake()
    {
        if (_bonus == null)
        {
            _bonus = Resources.Load("DefeatBonus") as GameObject;
        }
    }
    // zabierz
    public GameObject Pull()
    {
        var inPool = _bonuses.FirstOrDefault();
        if (inPool != null)
        {
            _bonuses.Remove(inPool);
            inPool.SetActive(true);
            return inPool;
        }
        inPool = Instantiate(_bonus);
        Destroy(inPool, 3f);
        return inPool;
    }
    // oddaj
    public void Push(GameObject toPool)
    {
        toPool.SetActive(false);
        _bonuses.Add(toPool);
    }
}
