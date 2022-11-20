using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Slider slider;

    private float currentStamina = 100.0f;
    private float maxStamina = 100.0f;
    private float sprintCost = 20.0f;
    private float staminaRegeneration = 20.0f;
    public float regenTimer = 0.0f;
    public float regenTimerSpeed = 10.0f;
    public bool isSprinting = false;

    private bool regeneratedStamina = true;

    public bool CanSprint() {
        return regeneratedStamina;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxStamina;
        slider.value = currentStamina;
    }

    public void UpdateStamina(float staminaValue) {
        slider.value = staminaValue;
    }

    // Update is called once per frame
    void Update()
    {

        if (regenTimer > 0.0f) {
            regenTimer -= regenTimerSpeed * Time.deltaTime;
        }

        if (!isSprinting) {
            if (currentStamina < maxStamina && regenTimer <= 0.0f) {
                currentStamina += staminaRegeneration * Time.deltaTime;

                if (currentStamina >= maxStamina) {
                    regeneratedStamina = true;
                    currentStamina = maxStamina;
                }
            }
        }
        else {
            currentStamina -= sprintCost * Time.deltaTime;

            if (currentStamina <= 0) {
                regeneratedStamina = false;
                currentStamina = 0.0f;
            }
        }

        // Update stamina on every frame
        UpdateStamina(currentStamina);
    }

    public void ResetRegenTimer() {
        regenTimer = 20.0f;
    }

    public void ShowStaminaBar() {
        gameObject.SetActive(true);
    }

    public void HideStaminaBar() {
        gameObject.SetActive(false);
    }
}
