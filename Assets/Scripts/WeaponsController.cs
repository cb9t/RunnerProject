using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class WeaponsController : MonoBehaviour
{
    [Header("Bullet Attacks")]
    [SerializeField] Rigidbody _bullet;
    [SerializeField] Transform _bulletSpawnPoint;
    [SerializeField] float _timePerShot;

    [SerializeField] private float _delayBulletDespawn;
    [SerializeField] private float _bulletSpeed;
    private bool _isBulletShoot;

    [Space]
    [Header("Rokets/Bombs")]
    [SerializeField] private Transform _attachedTo;

    [SerializeField] private WeaponsLogic[] _rockets;
    [SerializeField] private WeaponsLogic[] _bombs;

    [SerializeField] private Transform[] _rocketsPosition;
    [SerializeField] private Transform[] _bombsPosition;

    private int _currentRocket;
    private int _currentBombs;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadBombs();
            ReloadRockets();
        }
    }
    public void AttackRocket()
    {
        if (_currentRocket<_rockets.Length)
        {
            _rockets[_currentRocket].Detach();
            _rockets[_currentRocket].Attack();
            _currentRocket++;
        }
    }
    public void AttackBomb()
    {
        if (_currentBombs<_bombs.Length)
        {
            _bombs[_currentBombs].Detach();
            _bombs[_currentBombs].Attack();
            _currentBombs++;
        }
    }
    public void ReloadRockets()
    {
        for (int i = 0; i < _rockets.Length; i++)
        {
            _rockets[i].Attach(_attachedTo, _rocketsPosition[i]);
        }
        _currentRocket = 0;
    }
    public void ReloadBombs()
    {
        for (int i = 0; i < _bombs.Length; i++)
        {
            _bombs[i].Attach(_attachedTo, _bombsPosition[i]);
        }
        _currentBombs = 0;
    }
    public void AttackBulletStart()
    {
        _isBulletShoot = true;
        StartCoroutine(AttackBullet());
    }
    public void AttackBulletEnd()
    {
        _isBulletShoot = false;
        StopCoroutine(AttackBullet());
    }
    private IEnumerator AttackBullet()
    {
        while (_isBulletShoot)
        {
            var bullet = Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity);
            bullet.velocity = new Vector3(0f, 0f, _bulletSpeed);
            Destroy(bullet.gameObject, _delayBulletDespawn);
            yield return new WaitForSeconds(_timePerShot);
        }
    }
}
