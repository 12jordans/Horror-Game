using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract classs for all of our inventory items 
public abstract class ItemClass : ScriptableObject // shared across every item
{
    public string itemName;
    public Sprite itemIcon;

    public abstract ItemClass getItem();
    public abstract ToolClass getTool();
    public abstract PowerupClass getPowerup();
    public abstract WeaponClass getWeapon();
}
