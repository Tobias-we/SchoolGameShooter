using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] Slider healthSlider;

    void Start()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealthBar;
        }

        healthSlider.maxValue = 1;
        healthSlider.value = 1;
    }

    void UpdateHealthBar(float healthPercentage)
    {
        healthSlider.value = healthPercentage;
    }

    void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }
}
