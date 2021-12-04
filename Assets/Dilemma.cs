using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dilemma : MonoBehaviour
{
    private TMPro.TextMeshPro questionTextTMP;
    private TMPro.TextMeshPro questionTitleTMP;
    public void Init(Question question)
    {
        questionTextTMP = transform.Find("QuestionText").GetComponent<TMPro.TextMeshPro>();
        questionTitleTMP = transform.Find("QuestionTitle").GetComponent<TMPro.TextMeshPro>();
        SetQuestionText(question.question);
        SetQuestionTitle(question.questionTitle);
        int randomImageIndex = Random.Range(0, 5);
        transform.Find("Images").GetChild(randomImageIndex).gameObject.SetActive(true);
    }

    void SetQuestionText(string text)
    {
        questionTextTMP.SetText(text);
    }
    void SetQuestionTitle(string text)
    {
        questionTitleTMP.SetText(text);
    }
}
