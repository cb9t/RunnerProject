using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuScreen : MonoBehaviour
{
    public Action OnContinue;

    [SerializeField] private Button _buttonMenuStart;
    [SerializeField] private Button _buttonMenuMusic;
    [SerializeField] private Button _buttonMenuSounds;
    [SerializeField] private Button _buttonMenuExit;

    [SerializeField] private GameObject _scenePrefab;

    private GameObject _currentScene;

    private void OnEnable()
    {
        _buttonMenuStart.onClick.AddListener(OnStartButtonPressed);
        _buttonMenuMusic.onClick.AddListener(OnMusicButtonPressed);
        _buttonMenuSounds.onClick.AddListener(OnSoundsButtonPressed);
        _buttonMenuExit.onClick.AddListener(OnExitButtonPressed);
    }
    private void OnDisable()
    {
        _buttonMenuStart.onClick.RemoveListener(OnStartButtonPressed);
        _buttonMenuMusic.onClick.RemoveListener(OnMusicButtonPressed);
        _buttonMenuSounds.onClick.RemoveListener(OnSoundsButtonPressed);
        _buttonMenuExit.onClick.RemoveListener(OnExitButtonPressed);
    }
    public void OnStartButtonPressed()
    {
        _currentScene = Instantiate(_scenePrefab);
        OnContinue?.Invoke();
    }
    public void OnMusicButtonPressed() 
    {

    }
    public void OnSoundsButtonPressed()
    {

    }
    public void OnExitButtonPressed() 
    {
        Application.Quit();
    }
}
