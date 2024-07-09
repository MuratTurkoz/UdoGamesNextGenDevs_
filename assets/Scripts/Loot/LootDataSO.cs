using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loot Data")]
public class LootDataSO : ScriptableObject
{
    public Loot[] LootDataList;


    [System.Serializable]
    public class Loot
    {
        public ObjType LootObjType;
        [Range(0, 1)] public float DropChance;
    }
}
