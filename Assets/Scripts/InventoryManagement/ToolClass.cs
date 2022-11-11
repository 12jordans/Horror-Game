using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Inventory Item/Tool") ]
public class ToolClass : ItemClass
{
    [Header("Tool (inventory item) ")]

    public ToolType toolType; 
    public enum ToolType
    {
        flashlight,
        hammer
    }
    public override ItemClass getItem()
    {
        return this; 
    }
    public override ToolClass getTool()
    {
        return this; 
    }
    public override PowerupClass getPowerup()
    {
        return null; // returns null because this is not a misc or a weapon
    }
    public override WeaponClass getWeapon()
    {
        return null; 
    }
}
