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
        int polution = 10;
        int social = 10;

        healthBars.Find(x => x.healthType == "polution").removeHealth(polution);
        //healthBars.Find(x => x.healthType == "social").removeHealth(social);
    }

    void applyTestQuestion2()
    {

    }
}
