using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour {
	[SerializeField] Button _endButton;
	[SerializeField] Text _endText;

	private void Start()
	{
		this._endButton.gameObject.SetActive (false);
		this._endText.gameObject.SetActive (false);
	}

	public void OnEndButtonClick()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void ShowEndMessage()
	{
		this._endButton.gameObject.SetActive (true);
		this._endText.gameObject.SetActive (true);
		Time.timeScale = 0f;
	}

}
