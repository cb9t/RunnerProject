using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseScreen : MonoBehaviour
{
    public Action OnContinue;

    [SerializeField] private Button _buttonContinue;
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Button _buttonMusic;
    [SerializeField] private Button _buttonSounds;
    [SerializeField] private Button _buttonMainMenu;

    [SerializeField] private GameObject _scenePrefab;

    private GameObject _currentScene;

    private void OnEnable()
    {
        _buttonContinue.onClick.AddListener(OnContinueButtonPressed);
        _buttonRestart.onClick.AddListener(OnRestartButtonPressed);
        _buttonMusic.onClick.AddListener(OnMusicButtonPressed);
        _buttonSounds.onClick.AddListener(OnSoundsButtonPressed);
        _buttonMainMenu.onClick.AddListener(OnMainMenuButtonPressed);
    }
    private void OnDisable()
    {
        _buttonContinue.onClick.RemoveListener(OnContinueButtonPressed);
        _buttonRestart.onClick.RemoveListener(OnRestartButtonPressed);
        _buttonMusic.onClick.RemoveListener(OnMusicButtonPressed);
        _buttonSounds.onClick.RemoveListener(OnSoundsButtonPressed);
        _buttonMainMenu.onClick.RemoveListener(OnMainMenuButtonPressed);
    }
    public void OnContinueButtonPressed()
    {
        OnContinue?.Invoke();
    }
    public void OnRestartButtonPressed()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(_currentScene);
        _currentScene = Instantiate(_scenePrefab);
        OnContinue?.Invoke();
    }
    public void OnMusicButtonPressed() 
    {

    }
    public void OnSoundsButtonPressed()
    {

    }
    public void OnMainMenuButtonPressed() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.Quit();
    }
}
