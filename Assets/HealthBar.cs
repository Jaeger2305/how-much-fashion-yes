using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    private int health = 100;
    private int max = 100;
    private int min = 0;
    public UnityEvent maxExceeded;
    public UnityEvent minExceeded;
    public UnityEvent<int> healthUpdated;

    public void removeHealth(int amount)
    {
        setHealth(health - amount);
    }
    public void addHealth(int amount)
    {
        setHealth(health + amount);
    }

    private void setHealth(int amount)
    {
        health = amount;
        healthUpdated.Invoke(health);
        if (amount < min) minExceeded.Invoke();
        if (amount > max) maxExceeded.Invoke();
    }
}
