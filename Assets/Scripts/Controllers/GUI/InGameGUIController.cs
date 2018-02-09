using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameGUIController : MonoBehaviour
{

    #region Private Variables
    [SerializeField] private Button _backToGameBtn;
    [SerializeField] private Button _settingsBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private Button _backBtn;

    [SerializeField] private Slider _soundSR;
    [SerializeField] private Slider _sfxSR;

    [SerializeField] private Text _soundInfoTxt;
    [SerializeField] private Text _sfxInfoTxt;

    [SerializeField] private Canvas _inCanvas;
    [SerializeField] private float defaultScale;

    [SerializeField] private Camera _inGameCamera;

    [SerializeField] GameObject _menuCanvas;
    [SerializeField] SetGameCursor _setCur;
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

        _inGameCamera = GameObject.Find("InGameCamera").GetComponent<Camera>();

        defaultScale = Time.timeScale;
    }
    private void Update()
    {
        _inGameCamera.GetComponent<AudioListener>().enabled = true;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackToGameClick();
        }
    }
    public void OnEscape()
    {
        LoadGui();
    }
    public void LoadGui()
    {
        _setCur.ShowCursor(true);
        _setCur.SetGuiCursor();
        _inCanvas.enabled = true;
        Time.timeScale = 0f;
        DefaultGuiSetUp();
    }
    public void DefaultGuiSetUp()
    {
        _backToGameBtn.gameObject.SetActive(true);
        _settingsBtn.gameObject.SetActive(true);
        _exitBtn.gameObject.SetActive(true);

        _backBtn.gameObject.SetActive(false);
        _soundSR.gameObject.SetActive(false);
        _sfxSR.gameObject.SetActive(false);

        _soundInfoTxt.gameObject.SetActive(false);
        _sfxInfoTxt.gameObject.SetActive(false);
    }
    public void OnBackToGameClick()
    {
        _inCanvas.enabled = false;
        _setCur.ShowCursor(false);
        Time.timeScale = defaultScale;
    }
    public void OnSettingsClick()
    {
        _backToGameBtn.gameObject.SetActive(false);
        _settingsBtn.gameObject.SetActive(false);
        _exitBtn.gameObject.SetActive(false);

        _backBtn.gameObject.SetActive(true);
        _soundSR.gameObject.SetActive(true);
        _sfxSR.gameObject.SetActive(true);

        _soundInfoTxt.gameObject.SetActive(true);
        _sfxInfoTxt.gameObject.SetActive(true);
    }
    public void OnBackClick()
    {
        DefaultGuiSetUp();
    }
    public void OnExitClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
