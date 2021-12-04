using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public List<Question> questions;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Question question in questions)
            Debug.Log(question.question);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
