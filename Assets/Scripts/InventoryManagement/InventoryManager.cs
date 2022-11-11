using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemClass> items = new List<ItemClass>(); 

    public void Add(ItemClass item) // code this to when we interact with the item
    {
        items.Add(item); 
    }

    public void Remove( ItemClass item) // code this to when you press a button to drop the itme 
    {
        items.Remove(item); 
    }
}
