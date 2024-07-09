using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace IgnuxNex.SpaceConqueror
{
    [CustomEditor(typeof(Int))]
    public class IntEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Int intVariable = (Int)target;

            if (GUILayout.Button("Update UI"))
            {
                intVariable.Value = intVariable.Value;
            }
        }
    }
}
