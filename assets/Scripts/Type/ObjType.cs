using UnityEngine;

[CreateAssetMenu(menuName ="Type")]
public class ObjType : ScriptableObject
{
    [SerializeField] private string tName;
    public string TName => tName;
}
