using System;
using System.Collections.Generic;
using UnityEngine;


public class AnimalSelection : MonoBehaviour
{
    private List<Animals> remainingAnimals;

    void Start()
    {
        FillAnimalsList();
    }

    void Update()
    {
        print(AnimalSelect());
    }

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
}