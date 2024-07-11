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

    private void Awake() {
        
    }

    private void OnDestroy() {
        
    }

    private void OnEnable() {
        
    }

}
