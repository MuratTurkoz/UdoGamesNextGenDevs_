using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public static Action OnEnemyDie;
    [SerializeField] private LootDataSO _lootDatas;
    [SerializeField] private float _maxHealth;
    private float _health;

    private void OnEnable()
    {
        _health = _maxHealth;
    }

    private void DestroyEnemy()
    {
        foreach (var loot in _lootDatas.LootDataList)
        {
            float rand = UnityEngine.Random.Range(0, 1f);
            if (rand <= loot.DropChance)
            {
                var lootObj = PoolManager.Instance.Get(loot.LootObjType);
                lootObj.transform.position = transform.position + new Vector3(UnityEngine.Random.Range(-0.2f, 0.2f), UnityEngine.Random.Range(-0.2f, 0.2f), 0);
            }
        }
        gameObject.SetActive(false);
        OnEnemyDie?.Invoke();
    }

    public void ApplyDamage(float damage)
    {
        if (_health <= 0) return;

        _health -= damage;
        DamageIndicatorManager.Instance.ShowDamage(transform.position, damage, DamageIndicatorType.EnemyIndicator);
        if (_health <= 0)
        {
            DestroyEnemy();
        }
    }
}
