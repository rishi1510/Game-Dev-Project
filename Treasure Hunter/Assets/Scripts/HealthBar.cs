using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject textMesh;
    
    public void setHealth(float health) {
        slider.value = health;
        string text = health.ToString() + "/" + slider.maxValue.ToString();
        textMesh.GetComponent<TextMeshProUGUI>().SetText(text);
    }

    public void setMaxHealth(float health, float maxHealth) {
        slider.maxValue = maxHealth;
        slider.value = health;

        string text = health.ToString() + "/" + slider.maxValue.ToString();
        textMesh.GetComponent<TextMeshProUGUI>().SetText(text);
    }
}
