using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SimpleQuestionCheck : MonoBehaviour
{
    [System.Serializable]
    public class AnswerUI
    {
        public Image imageField;
    }

    [System.Serializable]
    public class AnimalList
    {
        public UnityEngine.Object Object;   // Prefabs
    }

    public List<AnimalList> Animal;
    public Transform spawnPoint;            // <<< ONLY ONE SPAWN POINT

    public AnswerUI[] answerUIObjects;

    public List<AnswerData> correctAnswers;
    public List<AnswerData> wrongAnswers;

    private int currentCorrectIndex = 0;
    private int currentWrongIndex = 0;

    private int correctIndex;
    private int roundCount = 0;

    private int currentAnimalIndex = 0;     // Which animal to spawn
    private GameObject currentAnimalObject; // The currently spawned animal

    void Start()
    {
        NewRound();
    }

    // =============================
    //      SPAWN / DESPAWN ANIMAL
    // =============================
    void SpawnAnimal()
    {
        // Destroy previously spawned animal
        if (currentAnimalObject != null)
            Destroy(currentAnimalObject);

        // Loop animal list
        if (currentAnimalIndex >= Animal.Count)
            currentAnimalIndex = 0;

        GameObject prefab = Animal[currentAnimalIndex].Object as GameObject;

        if (prefab != null)
        {
            currentAnimalObject = Instantiate(
                prefab,
                spawnPoint.position,
                prefab.transform.rotation
            );
        }
        else
        {
            Debug.LogWarning("Animal entry is not a GameObject prefab!");
        }

        currentAnimalIndex++;
    }


    // =============================
    //          NEW ROUND
    // =============================
    void NewRound()
    {
        roundCount++;

        // Spawn the next animal (and delete old one)
        SpawnAnimal();

        // Load next scene after round 6
        if (roundCount >= 6)
        {
            SceneManager.LoadScene("Main Menu");
            return;
        }

        // Answer logic
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

        // Shuffle list
        for (int i = 0; i < allAnswers.Count; i++)
        {
            int r = Random.Range(0, allAnswers.Count);
            (allAnswers[i], allAnswers[r]) = (allAnswers[r], allAnswers[i]);
        }

        // Set answer UI
        for (int i = 0; i < answerUIObjects.Length; i++)
        {
            answerUIObjects[i].imageField.sprite = allAnswers[i].image;

            if (allAnswers[i] == chosenCorrectAnswer)
                correctIndex = i;
        }
    }

    // =============================
    //    USER CLICKED AN ANSWER
    // =============================
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
