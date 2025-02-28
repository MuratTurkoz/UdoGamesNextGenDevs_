using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : PlayerExp
{
    public ObjectPool arrowPool;
    public TextMeshProUGUI ExpText;
    protected override void HandleOnReachExp()
    {
        base.HandleOnReachExp();
        LevelUpgrade();
    }
    protected override void HandleOnGetExp()
    {
        base.HandleOnGetExp();
        SetUI();
    }

    private void LevelUpgrade()
    {
       
    }

    private void UpgradeArrow()
    {
        foreach (var item in arrowPool.pool)
        {
            item.GetComponent<Arrow>().arrowSpeed.Value += 0.5f;
        }
    }

    private void SetUI()
    {
        ExpText.text = "EXP: "+ ExpAmaount.ToString();
    }
}
