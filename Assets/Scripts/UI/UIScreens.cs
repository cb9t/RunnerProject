using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class UIScreens : MonoBehaviour
{
    public Action StartGame;
    public Action Restart;
    public Action Continue;
    public Action Menu;
    public Action<bool> ToggleMusic;
    public Action<bool> ToggleSound;

    [Header("Pause Screen")]
    [SerializeField] private Button _buttonPauseContinue;
    [SerializeField] private Button _buttonPauseRestart;
    [SerializeField] private Toggle _togglePauseMusic;
    [SerializeField] private Toggle _togglePauseSounds;
    [SerializeField] private Button _buttonPauseMainMenu;
    [Space]
    [Header("Dead Screen")]
    [SerializeField] private Button _buttonDeadRestart;
    [SerializeField] private Button _buttonDeadMainMenu;
    [Space]
    [Header("Menu Screen")]
    [SerializeField] private Button _buttonMenuStart;
    [SerializeField] private Toggle _toggleMenuMusic;
    [SerializeField] private Toggle _toggleMenuSounds;
    [SerializeField] private Button _buttonMenuExit;
    [Space]
    [SerializeField] private GameObject _scenePrefab;

    private GameObject _currentScene;

    private void OnEnable()
    {
        _buttonPauseContinue.onClick.AddListener(OnContinueButtonPressed);
        _buttonPauseRestart.onClick.AddListener(OnRestartButtonPressed);
        _togglePauseMusic.onValueChanged.AddListener(OnPauseMusicTogglePressed);
        _togglePauseSounds.onValueChanged.AddListener(OnPauseSoundsTogglePressed);
        _buttonPauseMainMenu.onClick.AddListener(OnMainMenuButtonPressed);

        _buttonDeadRestart.onClick.AddListener(OnRestartButtonPressed);
        _buttonDeadMainMenu.onClick.AddListener(OnMainMenuButtonPressed);

        _buttonMenuStart.onClick.AddListener(OnStartButtonPressed);
        _toggleMenuMusic.onValueChanged.AddListener(OnMenuMusicTogglePressed);
        _toggleMenuSounds.onValueChanged.AddListener(OnMenuSoundsTogglePressed);
        _buttonMenuExit.onClick.AddListener(OnExitButtonPressed);
    }
    private void OnDisable()
    {
        _buttonPauseContinue.onClick.RemoveListener(OnContinueButtonPressed);
        _buttonPauseRestart.onClick.RemoveListener(OnRestartButtonPressed);
        _togglePauseMusic.onValueChanged.RemoveListener(OnPauseMusicTogglePressed);
        _togglePauseSounds.onValueChanged.RemoveListener(OnPauseSoundsTogglePressed);
        _buttonPauseMainMenu.onClick.RemoveListener(OnMainMenuButtonPressed);

        _buttonDeadRestart.onClick.RemoveListener(OnRestartButtonPressed);
        _buttonDeadMainMenu.onClick.RemoveListener(OnMainMenuButtonPressed);

        _buttonMenuStart.onClick.RemoveListener(OnStartButtonPressed);
        _toggleMenuMusic.onValueChanged.RemoveListener(OnMenuMusicTogglePressed);
        _toggleMenuSounds.onValueChanged.RemoveListener(OnMenuSoundsTogglePressed);
        _buttonMenuExit.onClick.RemoveListener(OnExitButtonPressed);
    }

    public void OnStartButtonPressed()
    {
        _currentScene = Instantiate(_scenePrefab);
        StartGame?.Invoke();
    }
    public void OnContinueButtonPressed()
    {
        Continue?.Invoke();
    }
    public void OnRestartButtonPressed()
    {
        Destroy(_currentScene);
        _currentScene = Instantiate(_scenePrefab);
        Restart?.Invoke();
    }
    public void OnMenuMusicTogglePressed(bool toggle)
    {
        ToggleMusic?.Invoke(toggle);
        _togglePauseMusic.isOn = _toggleMenuMusic.isOn;
    }
    public void OnMenuSoundsTogglePressed(bool toggle)
    {
        ToggleSound?.Invoke(toggle);
        _togglePauseSounds.isOn = _toggleMenuSounds.isOn;
    }
    public void OnPauseMusicTogglePressed(bool toggle)
    {
        ToggleMusic?.Invoke(toggle);
        _toggleMenuMusic.isOn = _togglePauseMusic.isOn;
    }
    public void OnPauseSoundsTogglePressed(bool toggle)
    {
        ToggleSound?.Invoke(toggle);
        _toggleMenuSounds.isOn = _togglePauseSounds.isOn;
    }
    public void OnMainMenuButtonPressed()
    {
        Destroy(_currentScene);
        Menu?.Invoke();
    }
    public void OnExitButtonPressed()
    {
        Application.Quit();
    }
}
