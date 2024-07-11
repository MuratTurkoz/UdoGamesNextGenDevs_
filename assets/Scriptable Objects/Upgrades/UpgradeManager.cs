using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public Upgrade[] upgrades;
    public GameObject[] buttons;
    public float defaultDamageAmount = 5;
    public float defaultArrowSpeed = 5;
    [SerializeField] Float damageAmount;
    [SerializeField] Float arrowSpeed;
    private int maxNum;
    private List <int> randomList;


    
    void Start()
    {
     maxNum = upgrades.Length;   
     damageAmount.Value = defaultDamageAmount;
     arrowSpeed.Value = defaultArrowSpeed;  
        


    }

    public void PrepareUpgradePanel(){
        randomList = new List<int>();
        GenerateRandomList();
        
        for(int i = 0; i<buttons.Length; i++){
            
            buttons[i].GetComponent<UpgradeBtn>().SetUpgrade(upgrades[randomList[i]].name, upgrades[randomList[i]].description, 
            upgrades[randomList[i]].level, upgrades[randomList[i]].artwork, upgrades[randomList[i]].healthChange, 
            upgrades[randomList[i]].attackChange, upgrades[randomList[i]].speedChange, upgrades[randomList[i]].arrowSpeedChange,
            upgrades[randomList[i]].eyesBehindMyBack, upgrades[randomList[i]].concentrateFire, upgrades[randomList[i]].turningSword);
        }
    }

    public void GenerateRandomList (){
    for(int i = 0; i < maxNum; i++){
       int numToAdd = Random.Range(0,maxNum);
       while(randomList.Contains(numToAdd)){
          numToAdd = Random.Range(0,maxNum);
       }
       randomList.Add(numToAdd);

   }
    }
    
    
    void Update()
    {
        

    }
}
