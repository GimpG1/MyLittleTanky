using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour {
	[SerializeField] Button _endButton;
	[SerializeField] Text _endText;
	[SerializeField] Canvas _endCanvas;

	private void Start()
	{
		this._endButton.gameObject.SetActive (false);
		this._endText.gameObject.SetActive (false);
		_endCanvas = gameObject.GetComponent<Canvas> ();
		_endCanvas.enabled = false;
	}

	public void OnEndButtonClick()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void ShowEndMessage()
	{
		_endCanvas.enabled = true;
		this._endButton.gameObject.SetActive (true);
		this._endText.gameObject.SetActive (true);
	}

}
