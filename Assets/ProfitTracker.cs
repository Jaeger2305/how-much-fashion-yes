using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfitTracker : MonoBehaviour
{
    private float profit = 10000;

    private float currentTimer = 0;
    private float triggerTimer = 0;

    private void Start()
    {
        UpdateProfitDisplay();
    }

    void Update()
    {
        // Add a random profit amount at random intervals
        currentTimer += Time.deltaTime;
        if (currentTimer > triggerTimer)
        {
            AddProfit(Random.Range(100, 300));
            currentTimer = 0;
            triggerTimer = Random.Range(1,3);
        }
    }

    public void AddProfit(float amount)
    {
        profit += amount;
        UpdateProfitDisplay();
    }

    public void AddProfit(Question question, bool answer)
    {
        AddProfit(answer ? Random.Range(2000, 5000) : -Random.Range(0, 500));
    }

    private void UpdateProfitDisplay()
    {
        string text = string.Format("€ {0:0.00} K", profit);
        this.GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText(text);
    }
}
