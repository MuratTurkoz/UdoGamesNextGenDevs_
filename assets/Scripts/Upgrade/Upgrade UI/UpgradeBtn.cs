using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// EMİRCAN

public class UpgradeBtn : MonoBehaviour
{
    public static Action OnUpgradeSelected;
    private Button _upgradeButton;
    [SerializeField] private TextMeshProUGUI _upgradeNameTMP;
    [SerializeField] private TextMeshProUGUI _upgradeDescriptionTMP;
    [SerializeField] private TextMeshProUGUI _upgradeLvlTMP;
    [SerializeField] private Image _upgradeIcon;

    [SerializeField] GameObject upgradeManager;
    [SerializeField] GameObject player;
    [SerializeField] Float damageAmount;
    [SerializeField] Float playerCurrentHealth;
    private float btnHealthChange;
    private float btnAttackChange;
    private float btnSpeedChange;

    private void Awake() {
        _upgradeButton = GetComponent<Button>();
        _upgradeButton.onClick.AddListener(OnUpgradeSelect);
    }

    private void OnUpgradeSelect()
    {
        OnUpgradeSelected?.Invoke();
        // APPLY UPGRADE
        player.GetComponent<PlayerMovement>().playerSpeed += btnSpeedChange;
        damageAmount.Value += btnAttackChange;
        playerCurrentHealth.Value += btnHealthChange; 
        
        


    }

    public void SetUpgrade(string name, string desc, int lvl, Sprite icon, float healthChange, float attackChange, float speedChange)
    {
        _upgradeNameTMP.text = name;
        _upgradeDescriptionTMP.text = desc;
        _upgradeLvlTMP.text = "lv." + lvl;
        _upgradeIcon.sprite = icon;

        btnHealthChange = healthChange;
        btnAttackChange = attackChange;
        btnSpeedChange = speedChange;
    }
}
