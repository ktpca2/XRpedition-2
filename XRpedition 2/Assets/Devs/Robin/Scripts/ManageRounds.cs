using UnityEngine;

public class ManageRounds : MonoBehaviour
{
    [SerializeField] private Generation generation;
    [SerializeField] private AnimalSelection animal;

    private int round = 0;
    private bool roundActive;

    private void Update()
    {
        StartRound();
        if (roundActive)
        {
            Round();
        }
        EndRound();
    }

    private void StartRound()
    {
        round++;
        generation.Generate(animal);
    }

    private void Round()
    {

    }

    private void EndRound()
    {
        animal.GetEnvironment();
    }
}
