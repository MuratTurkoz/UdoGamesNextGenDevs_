using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EMİRCAN

public class EnemySpawner : MonoBehaviour
{

    [System.Serializable]
    public class SpawnPhase
    {
        public EnemySpawnData[] EnemySpawnList;
        public int MaxAliveEnemyCount;
    }

    [System.Serializable]
    public class EnemySpawnData
    {
        public EnemySpawnDataSO EnemySpawnDataSO;
        [HideInInspector] public float NextSpawnTime;
    }

    [SerializeField] private SpawnPhase[] _spawnPhases;
    [SerializeField] private float _minSpawnDelay = 0.1f;
    private SpawnPhase _spawnPhase;

    private PlayerExp _playerExp;
    private bool _isSpawning;
    private int _aliveEnemyCounter;
    private bool _isSpawningFaster;

    private void Awake()
    {
        _playerExp = FindObjectOfType<PlayerExp>();
        _playerExp.OnReachExp += UpdateSpawnPhase;

        // ASSIGN ON GAME START
    }

    private void OnDestroy()
    {
        if (_playerExp) _playerExp.OnReachExp -= UpdateSpawnPhase;
    }

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        _isSpawning = true;

        _spawnPhase = _spawnPhases[0];
    }

    private void UpdateSpawnPhase()
    {
        _spawnPhase = _spawnPhases[Mathf.Min(_playerExp.PlayerLevel, _spawnPhases.Length - 1)];
    }

    private float CalculateSpawnDelay(float baseSpawnRate)
    {
        float spawnDelay = baseSpawnRate;
        float levelFactor = Mathf.Log(_playerExp.PlayerLevel + 1) + 1;

        if (_playerExp.PlayerLevel >= _spawnPhases.Length) spawnDelay /= levelFactor;

        if (_isSpawningFaster) spawnDelay /= 2;

        spawnDelay = Mathf.Max(spawnDelay, _minSpawnDelay);

        return spawnDelay;
    }

    private void Update()
    {
        if (!_isSpawning) return;

        if (_aliveEnemyCounter >= _spawnPhase.MaxAliveEnemyCount) return;

        foreach (var spawnData in _spawnPhase.EnemySpawnList)
        {
            if (Time.time >= spawnData.NextSpawnTime)
            {
                int spawnCount = Random.Range(spawnData.EnemySpawnDataSO.MinSpawnCount, spawnData.EnemySpawnDataSO.MaxSpawnCount);
                SpawnEnemy(spawnData.EnemySpawnDataSO.EnemyType, spawnCount);
                spawnData.NextSpawnTime = CalculateSpawnDelay(spawnData.EnemySpawnDataSO.EnemySpawnDelay) + Time.time;
                if (_aliveEnemyCounter >= _spawnPhase.MaxAliveEnemyCount) return;
            }
        }
    }

    private void SpawnEnemy(ObjType enemyType, int spawnCount)
    {
        Vector3 spawnPos = GetRandomSpawnPositionOutsideCamera();
        for (int i = 0; i < spawnCount; i++)
        {
            _aliveEnemyCounter++;
            var enemy = PoolManager.Instance.Get(enemyType);
            enemy.transform.position = spawnPos;

            // Calculate next spawn position near the first one
            spawnPos += new Vector3(1, 1, 0);

            if (_aliveEnemyCounter >= _spawnPhase.MaxAliveEnemyCount) return;
        }
    }

    private Vector3 GetRandomSpawnPositionOutsideCamera()
    {
        Camera mainCamera = Camera.main;
        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        Vector3 spawnPos = Vector3.zero;
        int edge = Random.Range(0, 4);

        switch (edge)
        {
            case 0: // Top
                spawnPos = new Vector3(Random.Range(-camWidth / 2, camWidth / 2), camHeight / 2, 0);
                break;
            case 1: // Bottom
                spawnPos = new Vector3(Random.Range(-camWidth / 2, camWidth / 2), -camHeight / 2, 0);
                break;
            case 2: // Left
                spawnPos = new Vector3(-camWidth / 2, Random.Range(-camHeight / 2, camHeight / 2), 0);
                break;
            case 3: // Right
                spawnPos = new Vector3(camWidth / 2, Random.Range(-camHeight / 2, camHeight / 2), 0);
                break;
        }

        return mainCamera.transform.position + spawnPos;
    }

}
