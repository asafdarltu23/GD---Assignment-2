using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI HealthText;

    private void Update()
    {
        HealthText.text = PlayerMechanics.Health.ToString() + " / " + PlayerMechanics.MaxHealth.ToString();
    }
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
    }
    public void setHealth(int health)
    {
        slider.value = health;
    }
}