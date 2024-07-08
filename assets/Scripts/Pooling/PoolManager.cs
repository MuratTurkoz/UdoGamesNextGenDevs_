using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{

    public static PoolManager Instance { get; private set;}

    [System.Serializable]
    private class PoolObject
    {
        public ObjType type;
        public GameObject prefab;
        public int poolSize;
    }

    private Dictionary<ObjType, List<GameObject>> pool;
    [SerializeField] private List<PoolObject> prefabs;

    protected void Awake()
    {
        Instance = this;

        pool = new Dictionary<ObjType, List<GameObject>>();

        foreach(var prefabList in prefabs)
        {
            pool[prefabList.type] = new List<GameObject>();

            for(int i = 0; i < prefabList.poolSize; i++)
            {
                GameObject obj = Instantiate(prefabList.prefab);
                obj.SetActive(false);
                pool[prefabList.type].Add(obj);
            }
        }
    }

    public GameObject Get(ObjType type)
    {
        GameObject obj = pool[type].Find(x => !x.activeSelf); 
        if(obj == null)
        {
            obj = Instantiate(prefabs.Find(x => x.type == type).prefab);
            pool[type].Add(obj);
        }
        else
            obj.SetActive(true);
        return obj;
    }

    public GameObject Get(string typeName)
    {
        ObjType type = null;
        foreach(var key in pool.Keys)
        {
            if(key.TName != typeName)
                continue;
            else
            {
                type = key;
                break;
            }
        }

        if (type == null)
        {
            Debug.LogError($"No object type named {typeName} exists in the pool manager.");
            return null;
        }

        return Get(type);
    }

}