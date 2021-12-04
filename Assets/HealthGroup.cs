using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthGroup : MonoBehaviour
{
    public UnityEvent healthBarMinimumReached;
    public UnityEvent healthBarMaximumReached;

    private List<HealthBar> healthBars = new List<HealthBar>();

    void Start()
    {
        HealthBar[] healthBars = gameObject.GetComponentsInChildren<HealthBar>();
        this.healthBars.AddRange(healthBars);

        this.healthBars.ForEach(b => {
            b.maxReached.AddListener(healthBarMaximumReached.Invoke);
            b.minReached.AddListener(healthBarMinimumReached.Invoke);
        });
    }


    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            applyQuestion(1);
        }
        if (Input.GetKeyDown("2"))
        {
            applyQuestion(2);
        }
    }

    void applyQuestion(int question)
    {
        if (question == 1) applyTestQuestion1();
        else if (question == 2) applyTestQuestion2();
    }

    void applyTestQuestion1()
    {
        healthBars.Find(x => x.healthType == "polution").removeHealth(10);
        healthBars.Find(x => x.healthType == "society").removeHealth(5);
        healthBars.Find(x => x.healthType == "image").removeHealth(2);
        healthBars.Find(x => x.healthType == "security").removeHealth(2);
        healthBars.Find(x => x.healthType == "profit").addHealth(5);
    }

    void applyTestQuestion2()
    {
        healthBars.Find(x => x.healthType == "society").addHealth(20);
        healthBars.Find(x => x.healthType == "image").addHealth(15);
        healthBars.Find(x => x.healthType == "security").addHealth(1);
        healthBars.Find(x => x.healthType == "profit").removeHealth(10);
    }
}
