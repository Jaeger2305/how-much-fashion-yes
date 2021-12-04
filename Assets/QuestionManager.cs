using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class QuestionManager : MonoBehaviour
{
    public List<Question> questions;
    public GameObject cardPrefab;
    public UnityEvent<Question, bool> answerActiveDilemma;
    private GameObject activeCard;

    void Start()
    {
        DrawRandomQuestion();
    }

    // I couldn't get the new input to work with onMouseDown of a sprite, so there's an awkward duplicate way of calling the answering of the question :(
    public void QuestionInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AnswerActiveQuestion(context.action.name == "Confirm"); //hacky hacky :(
        }
    }

    public void AnswerActiveQuestion(bool answer)
    {
        Dilemma q = activeCard.GetComponentInChildren<Dilemma>();
        answerActiveDilemma.Invoke(q.question, answer);
        Destroy(activeCard);
        DrawRandomQuestion();
    }

    void DrawRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, questions.Count);
        activeCard = Instantiate(cardPrefab);
        activeCard.GetComponent<Dilemma>().Init(questions[randomQuestionIndex]);
        // questions.RemoveAt(randomQuestionIndex); // in theory, we wouldn't recycle the questions, but we only have 2 at the moment :P
    }
}
