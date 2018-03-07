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
            GameObject model = (item.objectReferenceValue as pickUpItem).model;
            Transform t = (serializedObject.targetObject as scenePickUpItem).transform;
            if (model != null)
            {
                if (t.childCount > 0)
                    DestroyImmediate(t.GetChild(0).gameObject);

                GameObject n = Instantiate(model, t);
                n.tag = "Pick Up";

                ApplyLayerRecursively(t.gameObject, LayerMask.NameToLayer("Ignore Raycast"));
            }
        }
    }

    static void ApplyLayerRecursively(GameObject go, int layer)
    {
        foreach (var t in go.GetComponentsInChildren<Transform>())
        {
            t.gameObject.layer = layer;
        }
    }
}
