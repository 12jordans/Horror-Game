using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InventoryManager : MonoBehaviour
{ 
  
   [SerializeField] private GameObject slotHolder; 
   [SerializeField] private ItemClass itemToAdd; 

    public List<SlotClass> items = new List<SlotClass>();

    private GameObject[] slots;

    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        //set each slot
        for( int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;  // all slots in canvas stored in this arr
        }
        RefreshUI(); 
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
        if (slots != null)
        {
            slots.AddQuantity(1); 
        } else
        {
            items.Add(new SlotClass(item, 1)); 
        }

        RefreshUI(); 
    }

    public bool Remove( ItemClass item) // code this to when you press a button to drop the itme 

    {
        SlotClass tmp = Contains(item);
        if (tmp != null)
        {
            if(tmp.GetQuantity() > 1) { tmp.SubtractQuantity(1); }
            else
            {
                SlotClass slotRemove = null;  //might cause issues 
                foreach (SlotClass slot in items)
                {
                    if (slot.GetItem() == item)
                    {
                        slotRemove = slot;

                        break;
                    }
                }
                items.Remove(slotRemove);
            }
            // minus one from the item
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
