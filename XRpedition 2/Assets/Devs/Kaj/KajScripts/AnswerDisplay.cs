using System;
using UnityEngine;

public class AnswerDisplay : MonoBehaviour
{
    public int RoundsCorrectDisplay = 0;

    public void UpdateRoundsDisplay()
    {
        RoundsCorrectDisplay++;
        Debug.Log(RoundsCorrectDisplay.ToString() + " rounds correct!");
    }
}
