using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentHealthTest;

    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    public int CurrentHealth => _currentHealth;


    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
    void FixedUpdate()
    {
        _currentHealthTest.text = CurrentHealth.ToString(); 
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
