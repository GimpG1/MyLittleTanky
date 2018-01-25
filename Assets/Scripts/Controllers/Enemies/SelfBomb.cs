using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBomb : MonoBehaviour
{
    #region Private Variables
	[SerializeField] float _speed = 5f;
	[SerializeField] HeroStats hero;
	[SerializeField] DetectPlayer detector;
	[SerializeField] ObjectsAttackPOWER power;
	[SerializeField] BonusController defeatBonus;
    #endregion

    private void Awake()
    {
		if (hero == null)
		{
			hero = GameObject.Find("HeroTank").GetComponent<HeroStats>();
		}
		if (power == null) 
		{
			power = gameObject.GetComponent<ObjectsAttackPOWER> ();
			power.SetGetAttackPower = 30;
		}
		if (detector == null) 
		{
			detector = gameObject.GetComponent<DetectPlayer> ();
		}
		if (defeatBonus == null) 
		{
			defeatBonus = GameObject.Find("DefeatBonus").GetComponent<BonusController> ();
		}
    }

    private void Update()
    {
		if (detector.IsDetected)
        {
			SelfBombAttack (detector.HeroTransform);
        }
    }

	private void SelfBombAttack(Transform player)
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
		if (!collision.gameObject.CompareTag("Terrain"))
        {
			hero.TakeDamage (power.SetGetAttackPower);
			defeatBonus.SetBonusActive = true;
			defeatBonus.SpawnPlace (new Vector3(transform.position.x + 10,transform.position.y + 1, transform.position.z));
            Destroy(gameObject);
        }
    }
}
