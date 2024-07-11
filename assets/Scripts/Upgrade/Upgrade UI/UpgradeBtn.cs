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
    [SerializeField] Float arrowSpeed;
    [SerializeField] GameObject originalBow;
    [SerializeField] GameObject extraBow;
    [SerializeField] GameObject turningSword;
    private float btnHealthChange;
    private float btnAttackChange;
    private float btnSpeedChange;
    private float btnArrowSpeedChange;
    private bool btnEyesBehindMyBack;
    private bool btnConcentrateFire;
    private bool btnTurningSword;
    

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
        arrowSpeed.Value += arrowSpeed.Value * btnArrowSpeedChange;

        if(btnEyesBehindMyBack){
            extraBow.SetActive(true);
            //extraBow.transform.Rotate(0,originalBow.transform.rotation.y + 150,0);    
        }
        if(btnConcentrateFire){
            originalBow.GetComponent<Bow>().arrowCount = 3;
            extraBow.GetComponent<Bow>().arrowCount = 3;
        }
        if(btnTurningSword){
            turningSword.SetActive(true);
        }

        

        


    }

    public void SetUpgrade(string name, string desc, int lvl, Sprite icon, float healthChange, float attackChange, float speedChange, float arrowSpeedChange, bool eyesBehindMyBack, bool concentrateFire, bool turningSword)
    {
        _upgradeNameTMP.text = name;
        _upgradeDescriptionTMP.text = desc;
        _upgradeLvlTMP.text = "lv." + lvl;
        _upgradeIcon.sprite = icon;

        btnHealthChange = healthChange;
        btnAttackChange = attackChange;
        btnSpeedChange = speedChange;
        btnArrowSpeedChange = arrowSpeedChange;
        btnEyesBehindMyBack = eyesBehindMyBack;
        btnConcentrateFire = concentrateFire;
        btnTurningSword = turningSword;
    }
}
