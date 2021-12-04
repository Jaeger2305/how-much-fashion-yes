using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

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

    public void applyQuestion(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            int question = Random.Range(1, 3);
            if (question == 1) applyTestQuestion1();
            else if (question == 2) applyTestQuestion2();
        }
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
