using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour 
{
	[SerializeField] ObjectsFUEL fuel;
	[SerializeField] ObjectsAMMUNATION ammo;
	[SerializeField] HeroStats hero;
    [SerializeField] DefeatBonus bonus;
    private Vector3 defaultScale;
    private Vector3 scale;
	private void Awake()
	{
		if (fuel == null ||
            ammo == null ||
            hero == null) 
		{
			fuel = gameObject.GetComponent<ObjectsFUEL> ();
			fuel.SetGetFuel = Random.Range (100, 300);

            ammo = gameObject.GetComponent<ObjectsAMMUNATION>();
            ammo.SetGetAmmunation = Random.Range(2, 20);

            hero = GameObject.Find("Tanky").GetComponent<HeroStats>();
        }
	}

    private void Start()
    {
        defaultScale = new Vector3(0.2f,0.2f,0.2f);
    }
    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            scale.x = Mathf.Sin(Time.time * 0.5f);
            scale.z = Mathf.Sin(Time.time * 0.5f);
            scale.y = Mathf.Sin(Time.time * 0.5f);
            transform.localScale = scale;
        }
    }

    private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			hero.GetComponentInChildren<ObjectsFUEL>().SetGetFuel += fuel.SetGetFuel;
			hero.GetComponentInChildren<ObjectsAMMUNATION>().SetGetAmmunation += ammo.SetGetAmmunation;
            bonus.Push(gameObject);
            gameObject.SetActive(false);
		}
	}
}
