using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour // toggles inventory canvas UI on tab press
{

    public GameObject inventoryPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPanel.gameObject.SetActive(!inventoryPanel.gameObject.activeSelf); 
        }
    }

}
