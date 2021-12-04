using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempQuestionManager : MonoBehaviour
{
    public List<Question> questions;
    private Question activeQuestion;

    // Update is called once per frame
    void Update()
    {
        SelectQuestion();

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

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
