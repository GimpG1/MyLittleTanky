using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameGUIController : MonoBehaviour
{

    #region Private Variables
    private Button _backToGameBtn;
    private Button _settingsBtn;
    private Button _exitBtn;
    private Button _backBtn;

    private Slider _soundSR;
    private Slider _sfxSR;

    private Text _soundInfoTxt;
    private Text _sfxInfoTxt;

    private Canvas _inCanvas;
    [SerializeField] GameObject _menuCanvas;

    #endregion

    private void Awake()
    {
        _backToGameBtn = GameObject.Find("InBackToGameBTN").GetComponent<Button>();
        _settingsBtn = GameObject.Find("InSettingsBTN").GetComponent<Button>();
        _exitBtn = GameObject.Find("InExitGameBTN").GetComponent<Button>();
        _backBtn = GameObject.Find("InBackBTN").GetComponent<Button>();

        _soundSR = GameObject.Find("InSoundVolumeSR").GetComponent<Slider>();
        _sfxSR = GameObject.Find("InSFXVolumeSR").GetComponent<Slider>();

        _soundInfoTxt = GameObject.Find("InSoundInfo").GetComponent<Text>();
        _sfxInfoTxt = GameObject.Find("InSFXInfo").GetComponent<Text>();

        _inCanvas = gameObject.GetComponent<Canvas>();
        _inCanvas.enabled = false;
    }

    public void OnEscape()
    {
        
        Debug.Log("Esc pressed");
    }
}
