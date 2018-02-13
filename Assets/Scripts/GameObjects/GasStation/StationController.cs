using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    [SerializeField] private ObjectsFUEL _objFuel;
    [SerializeField] private HeroStats _heroStats;
    [SerializeField] private Material _mtl;

    private int maxFuel;
    private int amountFuel;

    private Color _empty = Color.red;
    private Color _half = Color.yellow;
    private Color _full = Color.green;

    private void Awake()
    {
        if (_objFuel == null ||
            _heroStats == null)
        {
            _objFuel = gameObject.GetComponent<ObjectsFUEL>();
            _heroStats = GameObject.Find("Tanky").GetComponent<HeroStats>();

            maxFuel = 300;
            _objFuel.SetGetFuel = 0;
        }
    }

    private void LateUpdate()
    {
        amountFuel = _objFuel.SetGetFuel;
        Debug.Log(amountFuel.ToString());
        if (amountFuel <= maxFuel)
        {
            ReloadStation(true);
            _mtl.color = _empty;
        }
        if (amountFuel >= (maxFuel/2))
        {
            ReloadStation(true);
            _mtl.color = _half;
        }
        if (amountFuel >= maxFuel)
        {
            _mtl.color = _full;
            ReloadStation(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _heroStats.GetComponentInChildren<ObjectsFUEL>().SetGetFuel += _objFuel.SetGetFuel;
            _objFuel.SetGetFuel = 0;
        }
    }

    private void ReloadStation(bool reload)
    {
        if (reload && amountFuel <= maxFuel)
        {
            _objFuel.SetGetFuel += 1;
        }
    }
    public int SetMaxFuel
    {
        set { maxFuel = value; }
    }
}
