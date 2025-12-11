using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SimpleQuestionCheck : MonoBehaviour
{
    [System.Serializable]
    public class AnswerUI
    {
        public Image ImageField;
    }

    [System.Serializable]
    public class AnimalList
    {
        public UnityEngine.Object Object;
    }

    public List<AnimalList> Animal;
    public Transform SpawnPoint;

    public AnswerUI[] AnswerUIObjects;

    public List<AnswerData> CorrectAnswers;
    public List<AnswerData> WrongAnswers;

    private int currentCorrectIndex = 0;
    private int currentWrongIndex = 0;

    private int correctIndex;
    private int roundCount = 0;

    private int currentAnimalIndex = 0;     // Dier het moet gaan spawnen
    private GameObject currentAnimalObject;

    void Start()
    {
        NewRound();
    }

    void SpawnAnimal()
    {
        if (currentAnimalObject != null)
            Destroy(currentAnimalObject);

        if (currentAnimalIndex >= Animal.Count)
            currentAnimalIndex = 0;

        GameObject prefab = Animal[currentAnimalIndex].Object as GameObject;

        if (prefab != null)
        {
            currentAnimalObject = Instantiate(
                prefab,
                SpawnPoint.position,
                prefab.transform.rotation
            );
        }
        else
        {
            Debug.LogWarning("Animal entry is not a GameObject prefab!");
        }

        currentAnimalIndex++;
    }

    void NewRound()
    {
        roundCount++;

        if (roundCount >= 6)
        {
            SceneManager.LoadScene("Win Scene");
            return;
        }

        SpawnAnimal();

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

            currentCorrectIndex++;

            if (currentCorrectIndex >= CorrectAnswers.Count)
                currentCorrectIndex = 0;

            NewRound();
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }
}
