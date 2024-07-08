using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EMİRCAN

[CreateAssetMenu(menuName = "Enemy/Enemy Spawn Data")]
public class EnemySpawnDataSO : ScriptableObject
{
    public ObjType EnemyType;
    public float EnemySpawnDelay;
    [Min(1)] public int MinSpawnCount = 1;
    [Min(1)] public int MaxSpawnCount = 1;
}
