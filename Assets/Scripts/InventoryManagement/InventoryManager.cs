using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InventoryManager : MonoBehaviour
{

    public GameObject InvenMessage;
    [SerializeField] private GameObject slotHolder; 
   [SerializeField] private ItemClass itemToAdd;
   [SerializeField] public ItemClass healthPowerup;
    public static bool addHealth_pu;
    public static bool useHealth_pu;
    public static bool hasHealthKit;
    public static bool showMessage; 


    public List<SlotClass> items = new List<SlotClass>();

    private GameObject[] slots;
    void Start()
    {
        
        slots = new GameObject[slotHolder.transform.childCount];
        //set each slot
        for( int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;  // all slots in canvas stored in this arr
        }
      
        addHealth_pu = false;
        useHealth_pu = false;
        showMessage = false; 
        RefreshUI(); 
    }
    private void Update()
    {
        if(Contains(healthPowerup) != null)
        {
            hasHealthKit = true;
        } else
        {
            hasHealthKit = false; 
        }

        if (addHealth_pu)
        {
            Add(healthPowerup); 
            addHealth_pu = false; 
        }

        if (useHealth_pu)
        {
            Remove(healthPowerup);
            useHealth_pu = false; 
        }
    }


    public void RefreshUI() // if item in slot, we set the image 
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true; 
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;  // each slot's first child is the image
            } catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null; // no item avaliable
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false; // no image 

            }
        }
    }
    public void Add(ItemClass item) // code this to when we interact with the item
    {
        //check if inv already contains item
        SlotClass slots = Contains(item); 
        items.Add(new SlotClass(item, 1));
        if ((Input.GetKeyDown(KeyCode.P))){
            showMessage = true; 
            InvenMessage.gameObject.SetActive(true);
        }
      
        RefreshUI(); 
    }

    public bool Remove( ItemClass item) // code this to when you press a button to drop the itme 

    {
        SlotClass tmp = Contains(item);
        if (tmp != null)
        {
                items.Remove(items[items.Count-1]);
        }
        else
        {
            return false; // nothing removed 
        }


        RefreshUI();
        return true; // successful remove
    }

    public SlotClass Contains(ItemClass item)
    {
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
                return slot; 
        }
        return null; 
    }
}

/* Source: ErinMakesGames on YouTube, Inventory System Tutorial -- 
 * A lot of the code for the inventory system is sourced from this series (the item classes as well), with customization added for 
 * this specific game. 
 */ 
