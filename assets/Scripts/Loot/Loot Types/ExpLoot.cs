using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLoot : LootBase
{
    [SerializeField] private int expAmount;

    protected override void OnCollect(GameObject player)
    {
        if (player.TryGetComponent<PlayerExp>(out var levelManager))
        {
            levelManager.GetExp(expAmount);
        }
    }
}
