using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
     
    public int maxHealth = 3;
    public int currentHealth;

    public HealthBar healthBar;
    public FollowPlayer followPlayer;
    private PowerupClass health_pack;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        followPlayer._index = 1;
        
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void setHealth(int newHealth)
    {
        currentHealth = newHealth; 
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && InventoryManager.hasHealthKit)
        {
            if (currentHealth <= maxHealth)
            {
                currentHealth++;
                healthBar.SetHealth(currentHealth);
                InventoryManager.useHealth_pu = true;

            }
        }
    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Health Kit")) {

            Destroy(other.gameObject);
            InventoryManager.addHealth_pu = true; 
        }
    }
}
