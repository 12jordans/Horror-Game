using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health) {
        slider.value = health;
    }

    public void ShowHealthBar() {
        gameObject.SetActive(true);
    }

    public void HideHealthBar() {
        gameObject.SetActive(false);
    }
}
