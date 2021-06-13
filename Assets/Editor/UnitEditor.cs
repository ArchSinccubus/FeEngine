using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Unit))]
public class SnapperEditor : Editor
{
    protected static bool ShowOffsetSettings = true;

    public static bool ShowPositionSettings;

    public List<SerializedProperty> Events;

    public List<SerializedProperty> Properties;

    private void OnEnable()
    {

            Events = new List<SerializedProperty>();
        Properties = new List<SerializedProperty>();

        if (Events.Count == 0)
        {
            

            SerializedProperty first = serializedObject.GetIterator().Copy();

            first.Next(true);

            while (first.NextVisible(false))
            {
                
                if (first.displayName.Contains("Event"))
                {
                    
                    Events.Add(first.Copy());
                }
                else if(first.displayName != "Script")
                {
                    Properties.Add(first.Copy());
                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        foreach (var item in Properties)
        {
            EditorGUILayout.PropertyField(item);

        }


        Rect rect = EditorGUILayout.GetControlRect(false, 1);

        rect.height = 1;

        EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));

        ShowPositionSettings = EditorGUILayout.Foldout(ShowPositionSettings, "Unit Events");

        if (ShowPositionSettings)
        {
            foreach (var item in Events)
            {
                EditorGUILayout.PropertyField(item);

            }
        }




        serializedObject.ApplyModifiedProperties();
    }

    
}
