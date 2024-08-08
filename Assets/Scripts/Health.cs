using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Action Death;

    [SerializeField] private bool _isPlayer;
    [SerializeField] private TextMeshProUGUI _currentHealthText;
    [SerializeField] private Slider _healthBar;

    [SerializeField] private int _maxHealth ;
    [SerializeField] private int _currentHealth;
    public int CurrentHealth => _currentHealth;


    
    private void Start()
    {
        {
            if (_isPlayer)
            {
                _healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
            }

            _currentHealth = _maxHealth;
            if (_healthBar != null)
            {
                _healthBar.maxValue = _maxHealth;
            }
        }
    }
    void FixedUpdate()
    {
       if (_currentHealthText != null) _currentHealthText.text = CurrentHealth.ToString(); 
       if (_healthBar != null) _healthBar.value = _currentHealth;

       if (_isPlayer)
        {
            if (_currentHealth == 0)
            {
                Death?.Invoke();
            }
        }
        
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0) 
        {
            _currentHealth = 0;
        }
    }
    public void Heal()
    {
        _currentHealth = _maxHealth;
    }

}
