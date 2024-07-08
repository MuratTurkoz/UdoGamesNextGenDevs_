using UnityEngine;
using System.Collections.Generic;

public class MonoPool : MonoBehaviour
{
    private List<GameObject> pool;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize;


    protected void Awake()
    {

        pool = new List<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject Get()
    {
        GameObject obj = pool.Find(x => !x.activeSelf); 
        if(obj == null)
        {
            obj = Instantiate(prefab);
            pool.Add(obj);
        }
        else
            obj.SetActive(true);
        return obj;
    }

}