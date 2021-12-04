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

    public void applyQuestion(Question question, bool accepted)
    {
        int i = 0;
        question.ePerformance.ForEach(p =>
        {
            healthBars.Find(x => x.healthType == question.questionType).removeHealth(accepted ? question.acceptValues[i++] : question.rejectValues[i++]);
        });
    }

}