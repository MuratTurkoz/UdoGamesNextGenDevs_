using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] private Float _currentHealth, _maxHealth;
    [SerializeField] private Image _healthBarImage;

    private void Awake()
    {
        _currentHealth.OnValueChanged += UpdateHealthBar;
    }

    private void OnDestroy()
    {
        _currentHealth.OnValueChanged -= UpdateHealthBar;    
    }

    private void UpdateHealthBar(float health)
    {
        _healthBarImage.fillAmount = health / _maxHealth;
    }
}
