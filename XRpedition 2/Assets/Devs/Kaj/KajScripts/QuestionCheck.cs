using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class SimpleQuestionCheck : MonoBehaviour
{
    public TextMeshProUGUI[] answerTexts; // Assign each button's text

    public string correctAnswer;
    public List<string> wrongAnswers;

    private int correctIndex;

    void Start()
    {
        NewRound();
    }

    void NewRound()
    {
        List<string> pool = new List<string>(wrongAnswers);
        pool.Add(correctAnswer);

        // Shuffle the answers
        for (int i = 0; i < pool.Count; i++)
        {
            int r = Random.Range(0, pool.Count);
            string temp = pool[i];
            pool[i] = pool[r];
            pool[r] = temp;
        }

        // Assign answers to UI and find correct index
        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = pool[i];

            if (pool[i] == correctAnswer)
                correctIndex = i;
        }
    }

    public void OnAnswerClicked(int index)
    {
        if (index == correctIndex)
        {
            Debug.Log("Correct!");
            NewRound();
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }
}