using System;
using System.Collections.Generic;
using UnityEngine;


public class AnimalSelection : MonoBehaviour
{
    [SerializeField] private List<EnvironmentData> environmentList;
    public EnvironmentData Environment;
    private List<Animals> remainingAnimals;

    private Animals selected;

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
        int index = 0;
        selected = remainingAnimals[index];
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