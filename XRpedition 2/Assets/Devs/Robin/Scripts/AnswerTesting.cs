using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AnswerTesting : MonoBehaviour
{
    public AnswerDisplay answerDisplay;

    [System.Serializable]
    public class AnswerUI
    {
        public Image ImageField;
    }

    [SerializeField] private ManageRounds rounds;

    public AnswerUI[] AnswerUIObjects;

    public List<AnswerData> CorrectAnswers;
    public List<AnswerData> WrongAnswers;

    private int currentCorrectIndex = 0;
    private int currentWrongIndex = 0;

    private int correctIndex;

    public void AnswerChecking()
    {
        AnswerData chosenCorrectAnswer = CorrectAnswers[currentCorrectIndex];

        List<AnswerData> roundWrongs = new List<AnswerData>();

        for (int i = 0; i < 3; i++)
        {
            if (currentWrongIndex >= WrongAnswers.Count)
                currentWrongIndex = 0;

            roundWrongs.Add(WrongAnswers[currentWrongIndex]);
            currentWrongIndex++;
        }

        List<AnswerData> allAnswers = new List<AnswerData>(roundWrongs);
        allAnswers.Add(chosenCorrectAnswer);

        // Shuffled de list
        for (int i = 0; i < allAnswers.Count; i++)
        {
            int r = Random.Range(0, allAnswers.Count);
            (allAnswers[i], allAnswers[r]) = (allAnswers[r], allAnswers[i]);
        }

        for (int i = 0; i < AnswerUIObjects.Length; i++)
        {
            AnswerUIObjects[i].ImageField.sprite = allAnswers[i].Image;

            if (allAnswers[i] == chosenCorrectAnswer)
                correctIndex = i;
        }
    }

    public void OnAnswerClicked(int index)
    {
        if (index == correctIndex)
        {
            Debug.Log("Correct!");
            answerDisplay.UpdateRoundsDisplay();

            currentCorrectIndex++;

            if (currentCorrectIndex >= CorrectAnswers.Count)
                currentCorrectIndex = 0;

            rounds.playCorrect();
        }
        else
        {
            Debug.Log("Wrong!");
            rounds.playWrong();
        }
        rounds.EndingRound();
    }
}
