using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public List<Upgrade> upgrades;
    public GameObject[] buttons;
    public float defaultDamageAmount = 5;
    public float defaultArrowSpeed = 5;
    [SerializeField] Float damageAmount;
    [SerializeField] Float arrowSpeed;
    
    private List <int> randomList;


    
    void Start()
    {
       IDEqualsIndex();   
     damageAmount.Value = defaultDamageAmount;
     arrowSpeed.Value = defaultArrowSpeed;  
        


    }

    public void PrepareUpgradePanel(){
        randomList = new List<int>();
        GenerateRandomList();
        
        for(int i = 0; i<buttons.Length; i++){
            
            buttons[i].GetComponent<UpgradeBtn>().SetUpgrade(upgrades[randomList[i]].name, upgrades[randomList[i]].description, 
            upgrades[randomList[i]].level, upgrades[randomList[i]].artwork, upgrades[randomList[i]].id, upgrades[randomList[i]].healthChange, 
            upgrades[randomList[i]].attackChange, upgrades[randomList[i]].speedChange, upgrades[randomList[i]].arrowSpeedChange,
            upgrades[randomList[i]].eyesBehindMyBack, upgrades[randomList[i]].concentrateFire, upgrades[randomList[i]].turningSword, upgrades[randomList[i]].upgradedVersion);
            
            
        }
    }

    public void GenerateRandomList (){
    for(int i = 0; i < upgrades.Count; i++){
       int numToAdd = Random.Range(0,upgrades.Count);
       while(randomList.Contains(numToAdd)){
          numToAdd = Random.Range(0,upgrades.Count);
       }
       randomList.Add(numToAdd);

   }
    }
    public void IDEqualsIndex(){
        for(int i=0; i<upgrades.Count; i++){
            upgrades[i].id = i;
        }
    }
    
    
    void Update()
    {
        

    }
}
