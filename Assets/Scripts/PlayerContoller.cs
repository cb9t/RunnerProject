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
    [SerializeField] private float _hightPosition;
    [SerializeField] private float _lerpValue;
    [SerializeField] private float _rangePositionX;
    
    private int _currentTrack;
    private InputManager _inputManager;

    void Awake()
    {
        _inputManager = new InputManager();

        _inputManager.Player.MoveLeft.performed += MoveLeft;
        _inputManager.Player.MoveRight.performed += MoveRight;
        _inputManager.Player.AttackBullet.started += AttackBulletStart;
        _inputManager.Player.AttackBullet.canceled += AttackBulletEnd;
        _inputManager.Player.AttackRocket.performed += AttackRocket;
        _inputManager.Player.AttackBomb.performed += AttackBomb;

        _currentTrack = 1;
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
        transform.position = new Vector3
            (Mathf.Lerp(currenrPositionX, targetPositionX, _lerpValue),_hightPosition,transform.position.z);
    }

    private void MoveLeft(InputAction.CallbackContext context)
    {
        var rangePosition = new Vector2(transform.position.x - _rangePositionX, transform.position.x + _rangePositionX);
        if (_tracksPosition[_currentTrack] > rangePosition.x && _tracksPosition[_currentTrack] < rangePosition.y)
            _animator.Play("MoveLeft");
        else _animator.Play("MoveDoubleLeft");

        if (_currentTrack > 0) _currentTrack--;

    }
    private void MoveRight(InputAction.CallbackContext context)
    {
        var rangePosition = new Vector2(transform.position.x - _rangePositionX, transform.position.x + _rangePositionX);
        if (_tracksPosition[_currentTrack] > rangePosition.x && _tracksPosition[_currentTrack] < rangePosition.y)
            _animator.Play("MoveRight");
        else _animator.Play("MoveDoubleRight");

        if (_currentTrack < 2) _currentTrack++;

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
