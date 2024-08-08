using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom.Input;
using static Custom.Input.InputPlayer;
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
    private InputPlayer _inputPlayer;

    void Awake()
    {
        _inputPlayer = new InputPlayer();

        _inputPlayer.Player.MoveLeft.performed += MoveLeft;
        _inputPlayer.Player.MoveRight.performed += MoveRight;
        _inputPlayer.Player.AttackBullet.started += AttackBulletStart;
        _inputPlayer.Player.AttackBullet.canceled += AttackBulletEnd;
        _inputPlayer.Player.AttackRocket.performed += AttackRocket;

        _currentTrack = 1;
    }
    private void OnEnable()
    {
        _inputPlayer.Enable();
    }
    private void OnDisable()
    {
        _inputPlayer.Disable();
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
    public void AttackBulletStart(InputAction.CallbackContext context)
    {
        _weapons.AttackBulletStart();
    }
    public void AttackBulletEnd(InputAction.CallbackContext context)
    {
        _weapons.AttackBulletEnd();
    }
}
