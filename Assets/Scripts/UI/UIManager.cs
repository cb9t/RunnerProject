using UnityEngine;
using Custom.Input;
using static Custom.Input.InputUI;
using UnityEngine.InputSystem;
using UnityEngine.Audio;


public class UIManager : MonoBehaviour, IUIActions
{
    [SerializeField] private RectTransform _pauseScreen;
    [SerializeField] private RectTransform _deathScreen;
    [SerializeField] private RectTransform _menuScreen;
    [SerializeField] private RectTransform _gameScreen;

    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private UIScreens _uiScreens;
    private bool _isPause = true;

    private void Awake()
    {
        InputController.SubscribeOnUIInput(this);
        _uiScreens.StartGame += StartGame;
        _uiScreens.Restart += Restart;
        _uiScreens.Continue += Continue;
        _uiScreens.Menu += Menu;
        _uiScreens.ToggleMusic += ToggleMusic;
        _uiScreens.ToggleSound += ToggleSound;


        InputController.DisablePlayerInput();
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
    }
    private void Update()
    {
        if (_isPause)
        {
            InputController.DisablePlayerInput();
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }
        else
        {
            InputController.EnablePlayerInput();
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }
    public void OnPauseToggle(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed) return;

        var isPlay = _deathScreen.gameObject.activeSelf == false && _menuScreen.gameObject.activeSelf == false;
        if(isPlay)
        {
            _isPause = !_isPause;
            _pauseScreen.gameObject.SetActive(_isPause);
        }
    }
    private void Continue()
    {
        _pauseScreen.gameObject.SetActive(false);
        _isPause = false;
    }
    private void StartGame()
    {
        Health.Death += Death;
        _menuScreen.gameObject.SetActive(false);
        _gameScreen.gameObject.SetActive(true);
        _isPause = false;

    }
    private void Restart()
    {
        _deathScreen.gameObject.SetActive(false);
        _pauseScreen.gameObject.SetActive(false);
        _isPause = false;
    }
    private void Death()
    {
        _deathScreen.gameObject.SetActive(true);
        _isPause = true;
    }
    private void Menu()
    {
        _gameScreen.gameObject.SetActive(false);
        _deathScreen.gameObject.SetActive(false);
        _pauseScreen.gameObject.SetActive(false);
        _menuScreen.gameObject.SetActive(true);
    }
    private void ToggleMusic(bool toggle)
    {
        if (toggle) _audioMixer.SetFloat("GameMusic", -80f);
        else _audioMixer.SetFloat("GameMusic", 0f);
    }
    private void ToggleSound(bool toggle)
    {
        if (toggle) _audioMixer.SetFloat("GameSounds", -80f);
        else _audioMixer.SetFloat("GameSounds", 0f);
    }
    private void OnEnable()
    {
        InputController.EnableUIInput();
    }
    private void OnDisable()
    {
        InputController.DisableUIInput();
    }
    private void OnDestroy()
    {
        InputController.UnsubscribeOnUIInput(this);
    }
}
