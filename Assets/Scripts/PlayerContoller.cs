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
    [Header("Tracks")]
    [SerializeField] private float[] _tracksPosition = { };
    [SerializeField] private float _lerpValue;
    
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
        var currenrPosition = transform.position.x;
        var targetPosition = _tracksPosition[_currentTrack];
        transform.position = new Vector3(Mathf.Lerp(currenrPosition, targetPosition, _lerpValue), transform.position.y, transform.position.z);
    }

    private void MoveLeft(InputAction.CallbackContext context)
    {
        if (_currentTrack > 0) _currentTrack--;
    }
    private void MoveRight(InputAction.CallbackContext context)
    {
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
