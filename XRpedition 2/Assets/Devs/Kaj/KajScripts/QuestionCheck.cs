using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SimpleQuestionCheck : MonoBehaviour
{
    [System.Serializable]
    public class AnswerUI
    {
        public Image imageField;
    }

    public AnswerUI[] answerUIObjects;

    public List<AnswerData> correctAnswers;
    public List<AnswerData> wrongAnswers;

    private int currentCorrectIndex = 0;
    private int currentWrongIndex = 0;  // <-- TRACK WRONG ANSWERS IN ORDER

    private int correctIndex;

    void Start()
    {
        NewRound();
    }

    void NewRound()
    {
        AnswerData chosenCorrectAnswer = correctAnswers[currentCorrectIndex];

        List<AnswerData> roundWrongs = new List<AnswerData>();

        for (int i = 0; i < 3; i++)
        {
            if (currentWrongIndex >= wrongAnswers.Count)
                currentWrongIndex = 0;

            roundWrongs.Add(wrongAnswers[currentWrongIndex]);
            currentWrongIndex++;
        }

        List<AnswerData> allAnswers = new List<AnswerData>(roundWrongs);
        allAnswers.Add(chosenCorrectAnswer);

        for (int i = 0; i < allAnswers.Count; i++)
        {
            int r = Random.Range(0, allAnswers.Count);
            (allAnswers[i], allAnswers[r]) = (allAnswers[r], allAnswers[i]);
        }

        for (int i = 0; i < answerUIObjects.Length; i++)
        {
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

            currentCorrectIndex++;

            if (currentCorrectIndex >= correctAnswers.Count)
                currentCorrectIndex = 0;

            NewRound();
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }
}
