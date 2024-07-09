using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Float))]
public class FloatEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Float intVariable = (Float)target;

        if (GUILayout.Button("Update UI"))
        {
            intVariable.Value = intVariable.Value;
        }
    }
}
