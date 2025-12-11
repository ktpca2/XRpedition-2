using UnityEngine;
using TMPro;

public class AnswerDisplay : MonoBehaviour
{
    public int RoundsCorrectDisplay = 0;
    public TextMeshProUGUI roundsText;

    private void Awake()
    {
        AnswerDisplay[] objs = FindObjectsOfType<AnswerDisplay>();
        if (objs.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateText();
    }

    public void UpdateRoundsDisplay()
    {
        RoundsCorrectDisplay++;
        UpdateText();
        Debug.Log(RoundsCorrectDisplay + " rounds correct!");
        SaveScore();
    }

    private void UpdateText()
    {
        if (roundsText != null)
        {
            roundsText.text = $"{RoundsCorrectDisplay} / 5";
        }
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("score", RoundsCorrectDisplay);
    }
}
