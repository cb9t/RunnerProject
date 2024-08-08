using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _collider;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private float _speed;
    [SerializeField] private float _lerpValue;

    [SerializeField] private float _maxDistance;
    [SerializeField] private Vector3 _defaultPosition;

    private bool _isFlying;

    private void FixedUpdate()
    {
        if (transform.position.z > _maxDistance)
        {
            _rb.velocity = Vector3.zero;
            _particle.gameObject.SetActive(false);
            transform.position = _defaultPosition;
        }
    }
    public void Attack()
    {
        _rb.AddForce(Vector3.forward * _speed, ForceMode.Impulse);
        _particle.gameObject.SetActive(true);
        _audioSource.Play();
    }
    public void Attach(Transform parent, Transform localPosition)
    {
        _rb.isKinematic = true;
        _collider.enabled = false;
        transform.SetParent(parent);
        transform.position = localPosition.position;
        _particle.gameObject.SetActive(false);
    }
    public void Detach()
    {
        _rb.isKinematic = false;
        _collider.enabled = true;
        transform.parent = null;
    }


}
