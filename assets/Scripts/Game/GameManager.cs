using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Float _playerHealth;

    [SerializeField] private Int _playerLevel;
    [SerializeField] private Int _playerScore;
    private float _timer;

    private void Awake() {
        Instance = this;
        _playerHealth.OnValueChanged += OnPlayerHealthChanged;
    }

    private void Start() {
        _playerScore.Value = 0;
    }

    private void OnDestroy() {
        _playerHealth.OnValueChanged -= OnPlayerHealthChanged;
    }

    private bool _isGameEnd;

    private void Update() {
        _timer += Time.deltaTime;
        if (_timer >= 1)
        {
            _timer = 0;
            _playerScore.Value += _playerLevel;
        }
    }

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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
