using System;
using UnityEngine;

public class AnswerDisplay : MonoBehaviour
{
    public int RoundsCorrectDisplay = 0;

    public void UpdateRoundsDisplay()
    {
        RoundsCorrectDisplay++;
        Console.WriteLine(RoundsCorrectDisplay.ToString(),"rounds correct!");
    }
}
