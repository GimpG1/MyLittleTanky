using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGUIController : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _settingsBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private Button _backBtn;

    [SerializeField] private Slider _soundSR;
    [SerializeField] private Slider _sfxSR;

    [SerializeField] private Text _soundInfoTxt;
    [SerializeField] private Text _sfxInfoTxt;

    [SerializeField] private Camera _mainMenuCamera;
    [SerializeField] private float defaultScale;

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

        _mainMenuCamera = GameObject.Find("MainMenuCamera").GetComponent<Camera>();
        _mainMenuCamera.GetComponent<AudioListener>().enabled = false;
        _setCur.ShowCursor(true);
        _setCur.SetGuiCursor();
        defaultScale = Time.timeScale;
    }

    private void Start()
    {
        _backBtn.gameObject.SetActive(false);
        _soundSR.gameObject.SetActive(false);
        _sfxSR.gameObject.SetActive(false);
        _mainMenuCamera.GetComponent<AudioListener>().enabled = true;
        _soundInfoTxt.gameObject.SetActive(false);
        _sfxInfoTxt.gameObject.SetActive(false);
    }

    public void OnStartClick()
    {
        _mainMenuCamera.GetComponent<AudioListener>().enabled = false;
        _mainMenuCamera.GetComponent<AudioSource>().Stop();
        Time.timeScale = defaultScale;
        _setCur.ShowCursor(false);
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
