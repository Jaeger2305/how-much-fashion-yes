using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    public string healthType; // a crappy form of ID, e.g. polution/environment/social etc.
    private int health = 100;
    private int max = 100;
    private int min = 0;
    public UnityEvent maxReached;
    public UnityEvent minReached;
    public UnityEvent<string> healthUpdated; // obviously weird type, just wanted it to work with set TMP text

    void Start()
    {
        if (healthType == null) throw new System.Exception("healthType should be specified in the editor, important for the HealthGroup class");
    }
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
        healthUpdated.Invoke(health.ToString());
        if (amount <= min) minReached.Invoke();
        if (amount >= max) maxReached.Invoke();
    }
}
