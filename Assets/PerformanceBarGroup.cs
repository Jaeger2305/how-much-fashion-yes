using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PerformanceBarGroup : MonoBehaviour
{
    public UnityEvent healthBarMinimumReached;
    public UnityEvent healthBarMaximumReached;

    private List<PerformanceBar> performanceBars = new List<PerformanceBar>();

    void Start()
    {
        PerformanceBar[] performanceBars = gameObject.GetComponentsInChildren<PerformanceBar>();
        this.performanceBars.AddRange(performanceBars);

        this.performanceBars.ForEach(b => {
            b.maxReached.AddListener(healthBarMaximumReached.Invoke);
            b.minReached.AddListener(healthBarMinimumReached.Invoke);
        });
    }

    public void applyQuestion(Question question, bool accepted)
    {
        int i = 0;
        question.ePerformance.ForEach(p =>
        {
            performanceBars.Find(x => x.ePerformance == question.questionType).addHealth(accepted ? question.acceptValues[i++] : question.rejectValues[i++]);
        });
    }

}