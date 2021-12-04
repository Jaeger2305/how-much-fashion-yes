using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EPerformance
{
    Pollution,
    Image,
    Society
}

public class PerformanceBar : MonoBehaviour
{
    public Slider slider;
    public EPerformance ePerformance;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
