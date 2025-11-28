using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TempAnimal
{
    private int round;

    void Start()
    {
        round = 1;
    }

    void NextRound(int round)
    {
        round++;
    }
}
