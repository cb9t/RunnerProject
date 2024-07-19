using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsLogic : MonoBehaviour
{
    public enum WeaponType {Rocket, Bomb }

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _collider;

    [SerializeField] private float _speed;
    [SerializeField] private float _lerpValue;
    [SerializeField] private WeaponType _weaponType;

    [SerializeField] private float _maxDistance;
    [SerializeField] private Vector3 _defaultPosition;


    public void Attack()
    {
        switch (_weaponType) 
        {
            case WeaponType.Rocket:
                _rb.AddForce(Vector3.forward * _speed , ForceMode.Impulse);
                if (transform.position.z > _maxDistance)
                {
                    transform.position = _defaultPosition;
                }

                break;
            case WeaponType.Bomb:
                _rb.useGravity = true;
                break;
        }
    }
    public void Attach(Transform parent, Transform localPosition)
    {
        _rb.isKinematic = true;
        _collider.enabled = false;
        transform.SetParent(parent);
        transform.position = localPosition.position;
    }
    public void Detach()
    {
        _rb.isKinematic = false;
        _collider.enabled = true;
        transform.parent = null;
    }


}
