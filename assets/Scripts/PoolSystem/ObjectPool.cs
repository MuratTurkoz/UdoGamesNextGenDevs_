using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   
    public GameObject obj
    {
        get {return GetObjectFromPool(); }
    }
    public List<GameObject> pool;

    public GameObject GetObjectFromPool()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
               
            }
        }

        return null;

    }
}
