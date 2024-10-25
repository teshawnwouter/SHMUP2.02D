using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public Slider slider;
    public Image fill;
    public Gradient gradient;

    private void Awake()
    {
        instance = this;
    }
    public void SetMaxHealth(int maxHealthShown)
    {
        slider.maxValue = maxHealthShown;
        slider.value = maxHealthShown;

        fill.color = gradient.Evaluate(1f);
        
    }
    public void SetHealth(int healthShown)
    {
        slider.value = healthShown;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
