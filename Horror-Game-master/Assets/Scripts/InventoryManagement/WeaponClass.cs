using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon Class", menuName = "Inventory Item/Weapon")]
public class WeaponClass : ItemClass
{

    [Header("Weapon (inventory item)")]

    public WeaponType weaponType;
    public enum WeaponType
    {
        axe,
        sledgehammer
    }
    public override ItemClass getItem()
    {
        return this; 
    }
    public override ToolClass getTool()
    {
        return null; 
    }
    public override PowerupClass getPowerup()
    {
        return null;  
    }
    public override WeaponClass getWeapon()
    {
        return this; 
    }

}
