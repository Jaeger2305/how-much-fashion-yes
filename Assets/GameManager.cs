using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Select canvas containing the performance bars
    public Canvas performanceCanvas;
    private List<PerformanceBar> performanceBars;

    // To be replaced by QuestionManager
    public List<Question> questions;
    private Question activeQuestion;

    private int dollarCount;


    private void Start()
    {
        dollarCount = 500_000_000;
        performanceBars = performanceCanvas.GetComponentsInChildren<PerformanceBar>().ToList();
        Debug.Log($"sliders: {performanceBars.Count}");
        foreach (PerformanceBar pBar in performanceBars)
            pBar.SetMaxValue(100);
    }

    // Update is called once per frame
    void Update()
    {
        SelectQuestion();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AnswerYes();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            AnswerNo();
        }
    }

    private void AnswerYes()
    {
        dollarCount += 200_000_000;
        foreach (PerformanceBar pBar in performanceBars)
        {
            for (int i = 0; i < activeQuestion.ePerformance.Count; i++)
            {
                if (activeQuestion.ePerformance[i] == pBar.GetEPerformance())
                {
                    int currentValue = pBar.GetValue();
                    pBar.SetValue(currentValue - activeQuestion.decreaseValues[i]);
                    Debug.Log($"{pBar.ePerformance} --> {pBar.GetValue()} ");
                }
            }
            // Get Enum with performance category
            pBar.GetEPerformance();
        }
        Debug.Log($"Yes! Our company is now worth {dollarCount} USD :D $$$$$$$$$$$$$$$$!!!!!");
    }
    private void AnswerNo()
    {
        dollarCount -= 200_000_000;
        Debug.Log($"No! We are worth only {dollarCount} USD :( !");
    }

    // To be replaced by QuestionManager
    private void SelectQuestion()
    {
        if (Input.GetKeyDown("0"))
        {
            activeQuestion = questions[0];
            Debug.Log(activeQuestion.question);
        }
        else if (Input.GetKeyDown("1"))
        {
            activeQuestion = questions[1];
            Debug.Log(activeQuestion.question);
        }
        else if (Input.GetKeyDown("2"))
        {
            activeQuestion = questions[2];
            Debug.Log(activeQuestion.question);
        }
    }
}
