using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    }
    public void OnEscape()
    {
        LoadGui();
    }
    public void LoadGui()
    {
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
        _setCur.SetInGameCursor(); ;
        _inCanvas.enabled = false;
        Time.timeScale = 1f;
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
