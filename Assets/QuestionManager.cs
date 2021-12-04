using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestionManager : MonoBehaviour
{
    public List<Question> questions;
    public GameObject cardPrefab;
    private GameObject activeCard;

    void Start()
    {
        DrawRandomQuestion();
    }

    public void AnswerActiveQuestion(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Destroy(activeCard);
            // TODO: connect to health system
            Debug.Log("not implemented - no impact on health bars");
            DrawRandomQuestion();
        }
    }

    void DrawRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, questions.Count);
        activeCard = Instantiate(cardPrefab);
        activeCard.GetComponent<Dilemma>().Init(questions[randomQuestionIndex]);
        // questions.RemoveAt(randomQuestionIndex); // in theory, we wouldn't recycle the questions, but we only have 2 at the moment :P
    }
}
