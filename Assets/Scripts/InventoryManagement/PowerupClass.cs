using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Powerup Class", menuName = "Inventory Item/Powerup")]
public class PowerupClass : ItemClass 
{
    [Header("Power Up (inventory item)")]
    public float healthAdded; // health added to player
    public float timeStunned; // time ghost gets stunned by powerup

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
        return this; // returns null because this is not a misc or a weapon
    }
    public override WeaponClass getWeapon()
    {
        return null;
    }
}
