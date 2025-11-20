using System;
using System.Collections.Generic;
using UnityEngine;


public class AnimalSelection : MonoBehaviour
{
    [SerializeField] private List<EnvironmentData> environmentList;
    public EnvironmentData Environment;
    private List<Animals> remainingAnimals;

    void Start()
    {
        FillAnimalsList();
        GetEnvironment();
    }

    /// <summary>
    /// This gives you a random animal and removes it from a list of potential animals.
    /// </summary>
    public Animals AnimalSelect()
    {
        int index = UnityEngine.Random.Range(0, remainingAnimals.Count);

        Animals selected = remainingAnimals[index];
        remainingAnimals.RemoveAt(index);

        return selected;
    }

    public void FillAnimalsList()
    {
        remainingAnimals = new List<Animals>((Animals[])Enum.GetValues(typeof(Animals)));
    }

    public void GetEnvironment()
    {
        Animals selectedAnimal = AnimalSelect();
        int index = (int)selectedAnimal;
        Environment = environmentList[index];
    }
}