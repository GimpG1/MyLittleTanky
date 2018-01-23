using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGUIController : MonoBehaviour
{
#region Private Variables
    private Button _startBtn;
    private Button _settingsBtn;
    private Button _exitBtn;
    private Button _backBtn;

    private Slider _soundSR;
    private Slider _sfxSR;

    private Text _soundInfoTxt;
    private Text _sfxInfoTxt;

    [SerializeField] GameObject _menuCanvas;
    [SerializeField] SetGameCursor _setCur;
    #endregion

    private void Awake()
    {
        _startBtn = GameObject.Find("StartBTN").GetComponent<Button>();
        _settingsBtn = GameObject.Find("SettingsBTN").GetComponent<Button>();
        _exitBtn = GameObject.Find("ExitBTN").GetComponent<Button>();
        _backBtn = GameObject.Find("BackBTN").GetComponent<Button>();

        _soundSR = GameObject.Find("SoundVolumeSR").GetComponent<Slider>();
        _sfxSR = GameObject.Find("SFXVolumeSR").GetComponent<Slider>();

        _soundInfoTxt = GameObject.Find("SoundInfo").GetComponent<Text>();
        _sfxInfoTxt = GameObject.Find("SFXInfo").GetComponent<Text>();
        _setCur.SetGuiCursor();
    }

    private void Start()
    {
        _backBtn.gameObject.SetActive(false);
        _soundSR.gameObject.SetActive(false);
        _sfxSR.gameObject.SetActive(false);

        _soundInfoTxt.gameObject.SetActive(false);
        _sfxInfoTxt.gameObject.SetActive(false);
        
    }

    public void OnStartClick()
    {
        _setCur.SetInGameCursor();
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlaceHolder");
    }

    public void OnSettingsClick()
    {
        _startBtn.gameObject.SetActive(false);
        _settingsBtn.gameObject.SetActive(false);
        _exitBtn.gameObject.SetActive(false);

        _backBtn.gameObject.SetActive(true);
        _soundSR.gameObject.SetActive(true);
        _sfxSR.gameObject.SetActive(true);

        _soundInfoTxt.gameObject.SetActive(true);
        _sfxInfoTxt.gameObject.SetActive(true);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnBackClick()
    {
        _startBtn.gameObject.SetActive(true);
        _settingsBtn.gameObject.SetActive(true);
        _exitBtn.gameObject.SetActive(true);

        _backBtn.gameObject.SetActive(false);
        _soundSR.gameObject.SetActive(false);
        _sfxSR.gameObject.SetActive(false);

        _soundInfoTxt.gameObject.SetActive(false);
        _sfxInfoTxt.gameObject.SetActive(false);
    }
    
}
