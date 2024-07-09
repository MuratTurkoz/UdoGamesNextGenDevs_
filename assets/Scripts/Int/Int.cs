using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Variables/Int")]
public class Int : ScriptableObject
{
    public Action<int> OnValueChanged;
    [SerializeField] private int _value;
    public int Value
    {
        get { return _value; }
        set
        {
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }

    // Implicit conversion to int
    public static implicit operator int(Int intVariable)
    {
        return intVariable.Value;
    }

    // Implicit conversion from int
    /* public static implicit operator Int(int value)
    {
        var instance = ScriptableObject.CreateInstance<Int>();
        instance.Value = value;
        return instance;
    } */

}

