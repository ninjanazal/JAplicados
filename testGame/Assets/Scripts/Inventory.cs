using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Inventory : MonoBehaviour
{

    public class InventoryItem
    {
        public int count;
        public pickUpItem item;

        public InventoryItem(pickUpItem i, int c)
        {
            item = i;
            count = c;
        }
    }

    List<InventoryItem> items;
    public int Count { get { return items.Count; } }
    public InventoryItem this[int index] {get { return items[index]; }
    }

    // Use this for initialization
    void Start()
    {
        items = new List<InventoryItem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick Up")
        {
            if (AddInventoryItem(other.GetComponentInParent<scenePickUpItem>().item))
            {
                Destroy(other.transform.parent.gameObject);
            }
        }
    }

    private bool AddInventoryItem(pickUpItem item)
    {
        InventoryItem existing = items.Find(x => x.item.name == item.name);
        if (existing != null)
        {
            if (item.maxCount == 0 || existing.count < item.maxCount)
            {
                existing.count++;
                return true;
            }
            else
                return false;

        }
        else
        {
            items.Add(new InventoryItem(item, 1));
            return true;
        }
    }

}
