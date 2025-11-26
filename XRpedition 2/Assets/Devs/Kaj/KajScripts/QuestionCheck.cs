using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SimpleQuestionCheck : MonoBehaviour
{
    [System.Serializable]
    public class AnswerUI
    {
        public TextMeshProUGUI textField;
        public Image imageField;
    }

    public AnswerUI[] answerUIObjects;   // UI for each answer option

    public List<AnswerData> correctAnswers;  // Text+Image correct answers
    public List<AnswerData> wrongAnswers;    // Text+Image wrong answers

    private AnswerData chosenCorrectAnswer;
    private int correctIndex;

    void Start()
    {
        NewRound();
    }

    void NewRound()
    {
        // Pick one correct answer
        chosenCorrectAnswer = correctAnswers[Random.Range(0, correctAnswers.Count)];

        // Build answer list
        List<AnswerData> allAnswers = new List<AnswerData>(wrongAnswers);
        allAnswers.Add(chosenCorrectAnswer);

        // Shuffle
        for (int i = 0; i < allAnswers.Count; i++)
        {
            int r = Random.Range(0, allAnswers.Count);
            (allAnswers[i], allAnswers[r]) = (allAnswers[r], allAnswers[i]);
        }

        // Apply to UI
        for (int i = 0; i < answerUIObjects.Length; i++)
        {
            answerUIObjects[i].textField.text = allAnswers[i].text;
            answerUIObjects[i].imageField.sprite = allAnswers[i].image;

            if (allAnswers[i] == chosenCorrectAnswer)
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
