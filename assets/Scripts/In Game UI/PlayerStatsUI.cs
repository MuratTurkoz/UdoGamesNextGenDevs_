using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _attackDamageTMP;
    [SerializeField] private TextMeshProUGUI _attackRateTMP;
    [SerializeField] private TextMeshProUGUI _healthTMP;
    [SerializeField] private TextMeshProUGUI _moveSpeedTMP;
    [SerializeField] private TextMeshProUGUI _playerLvlTMP;

    [SerializeField] private Float _playerDamage;
    [SerializeField] private Int _playerLevel;
    [SerializeField] private Float _playerMaxHealth;
    [SerializeField] private Float _playerMoveSpeed;
    [SerializeField] private Float _attackRate;

    private void OnEnable() {
        _attackDamageTMP.SetText(_playerDamage.Value.ToString());
        _attackRateTMP.SetText(_attackRate.Value.ToString());
        _healthTMP.SetText(_playerMaxHealth.Value.ToString());
        _moveSpeedTMP.SetText(_playerMoveSpeed.Value.ToString());
        _playerLvlTMP.SetText((_playerLevel.Value + 1 ).ToString());
    }

}
