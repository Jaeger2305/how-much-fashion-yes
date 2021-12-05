using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject
{
    public string question;
    public string questionTitle;

    [System.Serializable]
    public struct PerformanceProfile
    {
        public EPerformance performanceType;
        public int performanceImpact;
    };

    public List<PerformanceProfile> acceptValues;
    public List<PerformanceProfile> rejectValues;
}
