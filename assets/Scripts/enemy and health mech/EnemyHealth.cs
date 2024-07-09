using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
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
            float rand = Random.Range(0, 1f);
            if (rand <= loot.DropChance)
            {
                var lootObj = PoolManager.Instance.Get(loot.LootObjType);
                lootObj.transform.position = transform.position + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);
                gameObject.SetActive(false);
            }
        }
    }

    public void ApplyDamage(float damage)
    {
        if (_health <= 0) return;

        _health -= damage;
        if (_health <= 0)
        {
            DestroyEnemy();
        }
    }
}
