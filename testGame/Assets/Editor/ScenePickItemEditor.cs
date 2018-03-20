using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(scenePickUpItem))]
public class ScenePickItemEditor : Editor
{

    SerializedProperty item;

    public void OnEnable()
    {
        item = serializedObject.FindProperty("item");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (item.objectReferenceValue != null)
        {
            scenePickUpItem component = serializedObject.targetObject as scenePickUpItem;
            component.SetItem();
        }
    }

   
}
