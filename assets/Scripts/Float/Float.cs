using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float")]
public class Float : ScriptableObject
{
    public Action<float> OnValueChanged;
    [SerializeField] private float _value;
    public float Value
    {
        get { return _value; }
        set
        {
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }

    // Implicit conversion to float
    public static implicit operator float(Float floatVariable)
    {
        return floatVariable.Value;
    }
}
