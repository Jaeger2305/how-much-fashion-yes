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

    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void SetValue(int value)
    {
        slider.value = value;
    }

    public int GetValue()
    {
        return (int)slider.value;
    }

    public EPerformance GetEPerformance()
    {
        return ePerformance;
    }
}
