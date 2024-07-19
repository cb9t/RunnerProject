using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInput;
using static CustomInput.InputManager;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] WeaponsController _weapons;
    [SerializeField] Animator _animator;
    [Header("Tracks")]
    [SerializeField] private float[] _tracksPosition = { };
    [SerializeField] private Vector2 _hightPosition;
    [SerializeField] private float _lerpValue;
    
    private int _currentTrack;
    private float _currentHight;
    private InputManager _inputManager;

    void Awake()
    {
        _inputManager = new InputManager();

        _inputManager.Player.MoveLeft.performed += MoveLeft;
        _inputManager.Player.MoveRight.performed += MoveRight;
        _inputManager.Player.MoveUp.performed += MoveUp;
        _inputManager.Player.MoveDown.performed += MoveDown;
        _inputManager.Player.AttackBullet.started += AttackBulletStart;
        _inputManager.Player.AttackBullet.canceled += AttackBulletEnd;
        _inputManager.Player.AttackRocket.performed += AttackRocket;
        _inputManager.Player.AttackBomb.performed += AttackBomb;

        _currentTrack = 1;
        _currentHight = _hightPosition.x;
    }
    private void OnEnable()
    {
        _inputManager.Enable();
    }
    private void OnDisable()
    {
        _inputManager.Disable();
    }

    void Update()
    {
        UpdatePosition();
    }
    private void UpdatePosition()
    {
        var currenrPositionX = transform.position.x;
        var targetPositionX = _tracksPosition[_currentTrack];
        var currenrPositionY = transform.position.y;
        var targetPositionY = _currentHight;
        transform.position = new Vector3
            (Mathf.Lerp(currenrPositionX, targetPositionX, _lerpValue),
            Mathf.Lerp(currenrPositionY, targetPositionY, _lerpValue),
            transform.position.z);
    }

    private void MoveLeft(InputAction.CallbackContext context)
    {
        if (_currentTrack > 0) _currentTrack--;

        _animator.Play("MoveLeft");
    }
    private void MoveRight(InputAction.CallbackContext context)
    {
        if (_currentTrack < 2) _currentTrack++;

        _animator.Play("MoveRight");
    }
    private void MoveUp(InputAction.CallbackContext context)
    {
        if (transform.position.y != _hightPosition.x) _currentHight = _hightPosition.x;
    }
    private void MoveDown(InputAction.CallbackContext context)
    {
        if (transform.position.y != _hightPosition.y) _currentHight = _hightPosition.y;
    }
    public void AttackRocket(InputAction.CallbackContext context)
    {
        _weapons.AttackRocket();
    }
    public void AttackBomb(InputAction.CallbackContext context)
    {
        _weapons.AttackBomb();
    }
    public void AttackBulletStart(InputAction.CallbackContext context)
    {
        _weapons.AttackBulletStart();
    }
    public void AttackBulletEnd(InputAction.CallbackContext context)
    {
        _weapons.AttackBulletEnd();
    }
}
