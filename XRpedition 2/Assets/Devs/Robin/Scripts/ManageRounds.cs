using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SimpleQuestionCheck;

public class ManageRounds : MonoBehaviour
{
    public List<AnimalList> Animal;

    [SerializeField] private Generation generation;
    [SerializeField] private AnimalSelection animal;
    [SerializeField] private SoundManager _soundManager;

    private Animals animals;
    [SerializeField] private AnswerTesting answer;

    [SerializeField] private EnvironmentData[] environmentData;
    [SerializeField] private AudioSource walkietalkie;

    [SerializeField] private Button[] buttons;

    [SerializeField] private Transform[] SpawnPoints;

    private int currentAnimalIndex = 0;     // Dier het moet gaan spawnen
    private GameObject currentAnimal;
    private List<GameObject> currentAnimals;

    private int round = 1;
    public bool roundActive;

    private float audioTime;

    private void Start()
    {
        currentAnimals = new List<GameObject>();
        StartRound();
    }

    private void SpawnAnimal()
    {
        if (currentAnimalIndex >= Animal.Count)
            currentAnimalIndex = 0;

        GameObject prefab = Animal[currentAnimalIndex].Object as GameObject;

        foreach (Transform spawnPoint in SpawnPoints)
        {
            if (prefab != null)
            {
                currentAnimal = Instantiate(
                    prefab,
                    spawnPoint.position,
                    prefab.transform.rotation
                );
                currentAnimals.Add(currentAnimal);
            }
            else
            {
                Debug.LogWarning("Animal entry is not a GameObject prefab!");
            }
        }

        currentAnimalIndex++;
    }

    private void DespawnAnimal()
    {
        foreach (GameObject animal in currentAnimals)
        {
            Destroy(animal);
        }
    }

    private void StartRound()
    {
        buttonInactive();
        answer.AnswerChecking();
        generation.Generate();
        StartCoroutine(buttonActive(environmentData[round-1].info));
        RoundSounds();
    }

    private void RoundSounds()
    {
        switch (round)
        {
            case 1:
                _soundManager.PlayPolarAmbience();
                walkietalkie.resource = environmentData[0].info;
                walkietalkie.Play();
                break;
            case 2:
                _soundManager.PlayAfricaAmbience();
                walkietalkie.resource = environmentData[1].info;
                walkietalkie.Play();
                break;
            case 3:
                _soundManager.PlayChainsawSound();
                walkietalkie.resource = environmentData[2].info;
                walkietalkie.Play();
                break;
            case 4:
                _soundManager.PlayJungleAmbience();
                walkietalkie.resource = environmentData[3].info;
                walkietalkie.Play();
                break;
            case 5:
                _soundManager.PlayPolarAmbience();
                walkietalkie.resource = environmentData[4].info;
                walkietalkie.Play();
                break;
        }
    }

    public void playCorrect()
    {
        walkietalkie.resource = environmentData[round - 1].correct;
        audioTime = environmentData[round - 1].correct.length;
    }

    public void playWrong()
    {
        walkietalkie.resource = environmentData[round - 1].wrong;
        audioTime = environmentData[round - 1].wrong.length;
    }

    private void buttonInactive()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }

    private IEnumerator buttonActive(AudioClip audio)
    {
        yield return new WaitForSeconds(audio.length);
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    public void EndingRound()
    {
        
        SpawnAnimal();
        buttonInactive();
        walkietalkie.Play();
        StartCoroutine(EndRound());
    }

    private IEnumerator EndRound()
    {
        yield return new WaitForSeconds(audioTime); 
        if (round >= 6)
        {
            SceneManager.LoadScene("Win Scene");
        }
        DespawnAnimal();
        roundActive = false;
        generation.DeleteLastRound();
        animal.GetEnvironment();
        round++;
        StartRound();
    }
}