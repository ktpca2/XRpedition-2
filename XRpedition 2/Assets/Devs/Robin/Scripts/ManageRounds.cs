using UnityEngine;

public class ManageRounds : MonoBehaviour
{
    [SerializeField] private Generation generation;
    [SerializeField] private AnimalSelection animal;

    private int round = 0;

    private void Update()
    {
        
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

    }
}
