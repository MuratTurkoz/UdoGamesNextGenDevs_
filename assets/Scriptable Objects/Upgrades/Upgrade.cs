using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class Upgrade : ScriptableObject
{
   public string upgradeName;
   public string description;
   public int level;

   public Sprite artwork;
   public float healthChange;
   public float attackChange;
   public float speedChange;

}