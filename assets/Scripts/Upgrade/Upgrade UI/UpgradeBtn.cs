using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] Float moveSpeed;
    [SerializeField] Float arrowSpeed;
    [SerializeField] GameObject originalBow;
    [SerializeField] GameObject bow180;
    [SerializeField] GameObject bow90;
    [SerializeField] GameObject bow270;
    [SerializeField] GameObject turningSword;
    private float btnHealthChange;
    private float btnAttackChange;
    private float btnSpeedChange;
    private float btnArrowSpeedChange;
    private bool btnEyesBehindMyBack;
    private bool btnConcentrateFire;
    private bool btnTurningSword;
    private bool btnAddCandie;
    private bool btnSplitBow;
    private int btnID;
    private Upgrade btnUpgradedVersion;
    

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
        moveSpeed.Value += btnSpeedChange;
        arrowSpeed.Value += arrowSpeed.Value * btnArrowSpeedChange;

        

        if(btnEyesBehindMyBack){
            bow180.SetActive(true);
            upgradeManager.GetComponent<UpgradeManager>().upgrades.RemoveAt(btnID);
        }
        if(btnConcentrateFire){
            originalBow.GetComponent<Bow>().arrowCount = 3;
            originalBow.GetComponent<Bow>().spreadAngle = 30;
            upgradeManager.GetComponent<UpgradeManager>().upgrades.RemoveAt(btnID);
            for(int i = 0; i<upgradeManager.GetComponent<UpgradeManager>().upgrades.Count; i++){
                if(upgradeManager.GetComponent<UpgradeManager>().upgrades[i].name == "Additional Candies"){
                    upgradeManager.GetComponent<UpgradeManager>().upgrades.RemoveAt(i);
                }
            }
            
            
            
        }
        if(btnTurningSword){
            turningSword.SetActive(true);
            upgradeManager.GetComponent<UpgradeManager>().upgrades.RemoveAt(btnID);
            
            
        }
        if(btnAddCandie){
            originalBow.GetComponent<Bow>().arrowCount = 2;
            originalBow.GetComponent<Bow>().spreadAngle = 5;
            bow180.GetComponent<Bow>().arrowCount = 2;
            bow180.GetComponent<Bow>().spreadAngle = 5;
            bow90.GetComponent<Bow>().arrowCount = 2;
            bow90.GetComponent<Bow>().spreadAngle = 5;
            bow270.GetComponent<Bow>().arrowCount = 2;
            bow270.GetComponent<Bow>().spreadAngle = 5;
            upgradeManager.GetComponent<UpgradeManager>().upgrades.RemoveAt(btnID);

             for(int i = 0; i<upgradeManager.GetComponent<UpgradeManager>().upgrades.Count; i++){
                if(upgradeManager.GetComponent<UpgradeManager>().upgrades[i].name == "Concentrate Fire"){
                    upgradeManager.GetComponent<UpgradeManager>().upgrades.RemoveAt(i);
                }
            }

        }
        if(btnSplitBow){
            bow90.SetActive(true);
            bow270.SetActive(true);
            upgradeManager.GetComponent<UpgradeManager>().upgrades.RemoveAt(btnID);
        }
        
        if(!(btnUpgradedVersion == null || btnConcentrateFire || btnEyesBehindMyBack || btnTurningSword)){
            upgradeManager.GetComponent<UpgradeManager>().upgrades.RemoveAt(btnID);
            upgradeManager.GetComponent<UpgradeManager>().upgrades.Add(btnUpgradedVersion);
        }

        upgradeManager.GetComponent<UpgradeManager>().IDEqualsIndex();


        


    }

    public void SetUpgrade(string name, string desc, int lvl, Sprite icon,int id, float healthChange, float attackChange, float speedChange, float arrowSpeedChange, bool eyesBehindMyBack, 
    bool concentrateFire, bool turningSword, bool addCandie, bool splitBow, Upgrade upgradedVersion)
    {
        _upgradeNameTMP.text = name;
        _upgradeDescriptionTMP.text = desc;
        _upgradeLvlTMP.text = "lv." + lvl;
        _upgradeIcon.sprite = icon;

        btnID = id;
        btnHealthChange = healthChange;
        btnAttackChange = attackChange;
        btnSpeedChange = speedChange;
        btnArrowSpeedChange = arrowSpeedChange;
        btnEyesBehindMyBack = eyesBehindMyBack;
        btnConcentrateFire = concentrateFire;
        btnTurningSword = turningSword;
        btnAddCandie = addCandie;
        btnSplitBow = splitBow;
        btnUpgradedVersion = upgradedVersion;
    }
   private void OnDestroy()
    {
        _upgradeButton.onClick.RemoveListener(OnUpgradeSelect);
    }
}
