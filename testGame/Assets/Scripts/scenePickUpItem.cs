using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenePickUpItem : MonoBehaviour
{

    public pickUpItem item;

    public void SetItem()
    {
        if (transform.childCount > 0)
            DestroyImmediate(transform.GetChild(0).gameObject);

        if (item)
        {
            GameObject n = Instantiate(item.model, transform);
            n.transform.localPosition = Vector3.zero;
            n.tag = "Pick Up";

            ApplyLayerRecursively(transform.gameObject, LayerMask.NameToLayer("Ignore Raycast"));
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
