using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageRounds : MonoBehaviour
{
    [SerializeField] private Generation generation;
    [SerializeField] private AnimalSelection animal;
    [SerializeField] private SoundManager _soundManager;

    private Animals animals;
    [SerializeField] private AnswerTesting answer;

    private int round = 1;
    public bool roundActive;

    private void Start()
    {
        StartRound();
    }

    private void Update()
    {
        if (round > 5)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    private void StartRound()
    {
        answer.AnswerChecking();
        generation.Generate(animal);
        roundActive = true;
        RoundSounds();
    }

    private void RoundSounds()
    {
        switch (round)
        {
            case 1:
                _soundManager.PlayPolarAmbience();
                break;
            case 2:
                _soundManager.PlayAfricaAmbience();
                break;
            case 3:
                _soundManager.PlayChainsawSound();
                break;
            case 4:
                _soundManager.PlayJungleAmbience();
                break;
            case 5:
                _soundManager.PlayPolarAmbience();
                break;
        }
    }

    public void EndingRound()
    {
        StartCoroutine(EndRound());
    }

    private IEnumerator EndRound()
    {
        yield return new WaitForSeconds(5);
        roundActive = false;
        animal.GetEnvironment();
        round++;
        StartRound();
    }
}