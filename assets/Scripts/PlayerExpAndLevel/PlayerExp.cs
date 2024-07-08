using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public Action OnReachExp;
    public Action OnGetExp;
    private int expAmaount;
    public int ExpAmaount { get { return expAmaount; } set { expAmaount = value; } }
    private int expCounter = 0;
    public List<int> ExpLimits;
    public int PlayerLevel { get { return expCounter; } }
    public float ExpPercent { get { return (float)ExpAmaount / GetExpLimitFromList(PlayerLevel); } }
    
    private void Start()
    {
        OnReachExp += HandleOnReachExp;
        OnGetExp += HandleOnGetExp;
    }

    public void GetExp(int exp)
    {
        ExpAmaount += exp;
        OnGetExp?.Invoke();
    }

    private void Update()
    {
        SetExp();
    }

    public void SetExp()
    {
        if (CheckExp(GetExpLimitFromList(expCounter)))
        {
            OnReachExp?.Invoke();
            expCounter++;
        }

    }
    private int GetExpLimitFromList(int index)
    {
        return index < ExpLimits.Count ? ExpLimits[index] : 1000;
    }
    private bool CheckExp(float limit)
    {
        if (ExpAmaount >= limit)
        {
            return true;
        }
        else
            return false;
    }

    protected virtual void HandleOnReachExp()
    {
        Debug.Log("Player has gained enough experience to level up");
    }
     protected virtual void HandleOnGetExp()
    {
        Debug.Log("Player has got Exp");
    }
}
