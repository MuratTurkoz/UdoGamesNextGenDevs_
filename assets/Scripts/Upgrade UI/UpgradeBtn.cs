using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBtn : MonoBehaviour
{
    public static Action OnUpgradeSelected;
    private Button _upgradeButton;
    [SerializeField] private TextMeshProUGUI _upgradeNameTMP;
    [SerializeField] private TextMeshProUGUI _upgradeDescriptionTMP;
    [SerializeField] private TextMeshProUGUI _upgradeLvlTMP;
    [SerializeField] private Image _upgradeIcon;

    private void Awake() {
        _upgradeButton.GetComponent<Button>();
        _upgradeButton.onClick.AddListener(OnUpgradeSelect);
    }

    private void OnUpgradeSelect()
    {
        OnUpgradeSelected?.Invoke();
        // APPLY UPGRADE
    }

    public void SetUpgrade(string name, string desc, int lvl, Sprite icon)
    {
        _upgradeNameTMP.text = name;
        _upgradeDescriptionTMP.text = desc;
        _upgradeLvlTMP.text = "lv." + lvl;
        _upgradeIcon.sprite = icon;
    }
}
