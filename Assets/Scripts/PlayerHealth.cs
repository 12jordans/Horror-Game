using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Take damage
        if (Input.GetKeyDown(KeyCode.Space)) {
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Health Kit") && currentHealth < maxHealth) {
            Destroy(other.gameObject);
            currentHealth += 1;
            healthBar.SetHealth(currentHealth);
        }
    }
}
