using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotClass
{
    [SerializeField] private ItemClass item;
    [SerializeField] private int quantity;

    public SlotClass(ItemClass _item, int quant)
    {
        item = _item;
        quantity = quant; 
    }

    public ItemClass GetItem() { return item;  }

    public int GetQuantity() { return quantity;  }

    public void AddQuantity(int _quantity)
    {
        quantity += _quantity; 
    }

    public void SubtractQuantity(int _quantity)
    {
        quantity -= _quantity; 
    }


}
