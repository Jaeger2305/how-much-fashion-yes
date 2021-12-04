using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public PerformanceBar performanceBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        performanceBar.SetValue(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    private void TakeDamage(int v)
    {
        currentHealth -= 10;
        performanceBar.SetValue(currentHealth);
    }
}
