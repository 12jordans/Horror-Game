using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;
    public HealthBar healthBar;
    public FollowPlayer followPlayer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        followPlayer._index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Take damage
        /*
        if (followPlayer._index == 3)
        {
            Debug.Log(followPlayer._index);
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
            followPlayer._index = 0;
            Debug.Log(followPlayer._index);
        }
        */

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Health Kit") && currentHealth < maxHealth) {
            Destroy(other.gameObject);
            currentHealth += 1;
            healthBar.SetHealth(currentHealth);
        }
    }
}
