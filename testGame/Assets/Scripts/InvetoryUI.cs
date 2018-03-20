using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvetoryUI : MonoBehaviour
{

    Inventory inventory;
    GameObject mainPanel;
    GameObject innerPanel;

    private void Start()
    {
        mainPanel = transform.GetChild(0).gameObject;
        inventory = GameObject.FindGameObjectWithTag("Player").transform.parent.GetComponent<Inventory>();

        innerPanel = mainPanel.transform.Find("InnerPanel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!mainPanel.activeSelf) populateInventory();
            // muda o estado de visivel 
            mainPanel.SetActive(!mainPanel.activeSelf);
        }
    }

    void populateInventory()
    {
        //contador de indices
        for (int i = 0; i < 4; i++)
        {
            Transform image = innerPanel.transform.GetChild(i);
            if (i < inventory.Count)
            {
                image.GetComponent<Image>().sprite = inventory[i].item.icon;
                image.GetChild(0).GetComponent<Text>().text = inventory[i].count.ToString();
                image.gameObject.SetActive(true);
            }
            else
            {
                image.gameObject.SetActive(false);
            }

        }
    }

    public void DropItem(int i)
    {
        GameObject drop = new GameObject();
        scenePickUpItem pick = drop.AddComponent<scenePickUpItem>();
        drop.transform.position = inventory.transform.position + inventory.transform.forward + inventory.transform.right + inventory.transform.up * 0.5f;
        pick.item = inventory[i].item;
        pick.SetItem();

        inventory.DropItem(i);
        populateInventory();
    }
}
