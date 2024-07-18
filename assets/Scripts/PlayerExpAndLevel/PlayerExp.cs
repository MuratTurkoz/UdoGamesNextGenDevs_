using System;
using System.Collections;
using System.Collections.Generic;
using IgnuxNex.SpaceConqueror;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public Action OnReachExp;
    public Action OnGetExp;
    [SerializeField] private Int expAmaount;
    public int ExpAmaount { get { return expAmaount; } set { expAmaount.Value = value; } }
    [SerializeField] private Int expCounter;
    [SerializeField] private Int targetExp;
    public List<int> ExpLimits;
    public int PlayerLevel { get { return expCounter; } }
    public float ExpPercent { get { return (float)ExpAmaount / GetExpLimitFromList(PlayerLevel); } }

    private void Awake()
    {
        expAmaount.Value = 0;
        expCounter.Value = 0;
        targetExp.Value = GetExpLimitFromList(expCounter);
    }

    private void OnEnable()
    {
        OnReachExp += HandleOnReachExp;
        OnGetExp += HandleOnGetExp;
    }
    private void OnDisable()
    {
        OnReachExp -= HandleOnReachExp;
        OnGetExp -= HandleOnGetExp;
    }

    public void GetExp(int exp)
    {
        //LogManager.Instance.ShowMessage("+" + exp + " xp!", Color.green);
        ExpAmaount += exp;
        OnGetExp?.Invoke();
        SetExp();
    }

    private void Update()
    {
        // SetExp();
    }

    public void SetExp()
    {
        if (CheckExp(GetExpLimitFromList(expCounter)))
        {
            Debug.Log("Choose your Boost ");
            OnReachExp?.Invoke();
            expCounter.Value++;
            targetExp.Value = GetExpLimitFromList(expCounter);
            expAmaount.Value = 0;
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
