using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryUI : MonoBehaviour
{

    Inventory inventory;
    GameObject mainPanel;

    private void Start()
    {
        mainPanel = transform.GetChild(0).gameObject;
        inventory = GameObject.FindGameObjectWithTag("Player").transform.parent.GetComponent<Inventory>();

        Debug.Log(inventory);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // muda o estado de visivel 
            mainPanel.SetActive(!mainPanel.activeSelf);
        }
    }
}
