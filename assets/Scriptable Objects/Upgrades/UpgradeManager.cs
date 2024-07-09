using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public Upgrade[] upgrades;
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        
       
        


    }

    public void PrepareUpgradePanel(){
        for(int i = 0; i<buttons.Length; i++){
            int random = Random.Range(0, upgrades.Length);
            buttons[i].GetComponent<UpgradeBtn>().SetUpgrade(upgrades[random].name, upgrades[random].description, 
            upgrades[random].level, upgrades[random].artwork, upgrades[random].healthChange, upgrades[random].attackChange, upgrades[random].speedChange);
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
