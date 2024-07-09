using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Float _playerHealth;

    private int _playerScore;
    public int PlayerScore => _playerScore;

    private void Awake() {
        Instance = this;
        _playerHealth.OnValueChanged += OnPlayerHealthChanged;
    }

    private void OnDestroy() {
        _playerHealth.OnValueChanged -= OnPlayerHealthChanged;
    }

    private bool _isGameEnd;

    private void OnPlayerHealthChanged(float value)
    {
        if (_isGameEnd) return;

        if (value <= 0)
        {
            _isGameEnd = true;
            GameOver();
        }
    }

    private void GameOver()
    {
        FindObjectOfType<EnemySpawner>().StopSpawning();
        FindObjectOfType<InGameUI>().ShowEndGame();
    }

    
}
