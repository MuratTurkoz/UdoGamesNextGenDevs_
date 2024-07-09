using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class Upgrade : ScriptableObject
{
   public string upgradeName;
   public string description;

   public Sprite artwork;
   public float healthChange;
   public float attackChange;

}
