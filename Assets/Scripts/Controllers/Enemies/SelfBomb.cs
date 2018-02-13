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
	[SerializeField] AudioSource _bomSource;
	[SerializeField] AudioClip _bomClip;
    [SerializeField] DefeatBonus defeatBonus;
    [SerializeField] GameObject _objBonus;
    private Vector3 _bonusPos;
    #endregion

    private void Awake()
    {
		if (hero == null ||
            power == null ||
            detector == null)
		{
			hero = GameObject.Find("Tanky").GetComponent<HeroStats>();

            power = gameObject.GetComponent<ObjectsAttackPOWER>();
            power.SetGetAttackPower = 30;

            detector = gameObject.GetComponent<DetectPlayer>();
        }
		_bomSource = gameObject.GetComponent<AudioSource> ();
		_bomSource.playOnAwake = false;

    }

    private void Start()
    {
        _bonusPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
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
            _objBonus = defeatBonus.Pull();
            _objBonus.transform.position = _bonusPos;
            if (!_bomSource.isPlaying || _bomSource.isPlaying)
            {
                _bomSource.enabled = true;
                _bomSource.clip = _bomClip;
                _bomSource.Play();
            }
			Destroy(gameObject);
        }
    }
}
