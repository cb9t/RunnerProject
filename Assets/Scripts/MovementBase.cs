using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBase : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 10f;
    [SerializeField] private Score _currentScore;
    [SerializeField] private bool _isCustom;
    [SerializeField] private float _multiplierCustom;
    private float _moveSpeed;
    private Rigidbody _rb;
    
    void Start()
    {
        _currentScore = FindObjectOfType<Score>().GetComponent<Score>();
        _rb = GetComponent<Rigidbody>();  
    }

    
    void FixedUpdate()
    {
        
        var multiplierScore = _currentScore.score / 1000f;
        if (_isCustom) _moveSpeed = -((_startSpeed + multiplierScore) * _multiplierCustom);
        else _moveSpeed = -(_startSpeed + multiplierScore);
        
        _rb.velocity = new Vector3(0f,0f,_moveSpeed);

        if (transform.position.z < -10f) Destroy(gameObject);
    }
}
