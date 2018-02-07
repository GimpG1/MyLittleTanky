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
	[SerializeField] AudioSource _bomSource;
	[SerializeField] AudioClip _bomClip;
    #endregion

    private void Awake()
    {
		if (hero == null)
		{
			hero = GameObject.Find("Tanky").GetComponent<HeroStats>();
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
		_bomSource = gameObject.GetComponent<AudioSource> ();
		_bomSource.clip = _bomClip;
		_bomSource.playOnAwake = false;

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
			if (collision.gameObject.CompareTag("Player")) 
			{
				hero.TakeDamage (power.SetGetAttackPower);
			}
			defeatBonus.SetBonusActive = true;
			defeatBonus.SpawnPlace (new Vector3(transform.position.x - 3, transform.position.y + 1, transform.position.z - 3));
            if (_bomSource.isPlaying == false)
            {
                _bomSource.Play();
            }
			Destroy(gameObject);
        }
    }
}
