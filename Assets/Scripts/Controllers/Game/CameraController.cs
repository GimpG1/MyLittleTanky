using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
#region Private Variables
	[SerializeField] Transform _lookAtHero;//M/
	[SerializeField] Transform _heroFollow;//M/
    [SerializeField] HeroTowerController _towerController;
    [SerializeField] AudioClip[] backgroundSounds;
	private AudioSource _source;
    
	private Vector3 _camStartPos;
	//private Vector3 _cameraOffset;
   
	private float _camUpDist = 3f;
	private float _camBackDist = 10f;
    private float _camDistFromTarget = 0f;
    // Sound Control
    private int _playSoundAt = 0;
    private bool _isPlayingActually = false;
    #endregion

	private void Start ()
    {
        if (_lookAtHero == null)
        {
			_lookAtHero = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
		_source = gameObject.GetComponent<AudioSource> ();
		_source.Stop ();
        _playSoundAt = Random.Range(0, 5);
        ChangeBackGroundSound(_playSoundAt);
    }

	private void Update()
	{
        _camDistFromTarget = Vector3.Distance(transform.position, _heroFollow.transform.position);

		// Camera follow player
		transform.LookAt(_heroFollow);
		Vector3 endPos = new Vector3 (_heroFollow.transform.position.x ,
									  _heroFollow.transform.position.y + _camUpDist,
									  _heroFollow.transform.position.z - _camBackDist);
		
		/* Rotate camera at tower rotate
		_cameraOffset = (_lookAtHero.transform.position + new Vector3(0f, _camUpDist, 0f) - transform.position);
		Quaternion lookAtRotation = Quaternion.LookRotation (_cameraOffset);
		Quaternion actualRotation = transform.localRotation;
		*/
		// Summary
		//transform.position = endPos;
		transform.RotateAround (_lookAtHero.transform.position, Vector3.up, _towerController.GetSetTowerAngle * _camDistFromTarget);
        //transform.localRotation = Quaternion.Slerp (actualRotation , lookAtRotation, 1f * Time.deltaTime);

        if (!_source.isPlaying)
        {
            this._isPlayingActually = true;
        }
        if (_isPlayingActually)
        {
            _playSoundAt = Random.Range(0, 5);
            ChangeBackGroundSound(_playSoundAt);
            this._isPlayingActually = false;
        }
	}

	public void ChangeBackGroundSound(int soundIndex)
	{
		_source.clip = backgroundSounds[soundIndex];
		_source.Play ();
	}
}
