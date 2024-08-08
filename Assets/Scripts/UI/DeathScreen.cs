using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DeathScreen : MonoBehaviour
{
    public Action OnContinue;

    [SerializeField] private Button _buttonDeadRestart;
    [SerializeField] private Button _buttonDeadMainMenu;

    [SerializeField] private GameObject _scenePrefab;

    private GameObject _currentScene;

    private void OnEnable()
    {
        _buttonDeadRestart.onClick.AddListener(OnRestartButtonPressed);
        _buttonDeadMainMenu.onClick.AddListener(OnMainMenuButtonPressed);
    }
    private void OnDisable()
    {
        _buttonDeadRestart.onClick.RemoveListener(OnRestartButtonPressed);
        _buttonDeadMainMenu.onClick.RemoveListener(OnMainMenuButtonPressed);
    }
    public void OnRestartButtonPressed()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(_currentScene);
        _currentScene = Instantiate(_scenePrefab);
        OnContinue?.Invoke();

    }
    public void OnMainMenuButtonPressed() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.Quit();
    }
}
