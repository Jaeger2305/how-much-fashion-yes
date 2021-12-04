using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject
{
    public string question;
    public string questionTitle;

    public List<EPerformance> ePerformance;

    public List<int> acceptValues;
    public List<int> rejectValues;
}
