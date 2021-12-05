using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum EPerformance
{
    Pollution,
    Image,
    Society
}

// Warning - the names are abit strange here, because it was quickly merged code from the now deprecated health bar class
public class PerformanceBar : MonoBehaviour
{
    public Slider slider;
    public EPerformance ePerformance;
    public UnityEvent maxReached;
    public UnityEvent minReached;
    private int performance = 100;
    private int max = 100;
    private int min = 0;

    public void Start()
    {
        SetMaxValue(max); // this is a workaround, because I'm not sure what's calling the public SetMaxValue in other scenes
    }

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

    public void removeHealth(int amount)
    {
        setHealth(performance - amount);
    }
    public void addHealth(int amount)
    {
        setHealth(performance + amount);
    }

    private void setHealth(int amount)
    {
        performance = Mathf.Clamp(amount, min, max);
        slider.value = performance;
        if (amount <= min) minReached.Invoke();
        if (amount >= max) maxReached.Invoke();
    }

    public EPerformance GetEPerformance()
    {
        return ePerformance;
    }
}
