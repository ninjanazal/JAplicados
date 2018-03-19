using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    InvetoryUI inventory;
    private void Start()
    {
        inventory = GetComponentInParent<InvetoryUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                break;
            case PointerEventData.InputButton.Right:
                inventory.DropItem(transform.GetSiblingIndex());
                break;
        }
    }
}
