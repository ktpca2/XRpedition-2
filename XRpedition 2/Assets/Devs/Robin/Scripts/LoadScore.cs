using UnityEngine;

public class LoadScore : MonoBehaviour
{
    private int endScore;

    private void Start()
    {
        endScore = PlayerPrefs.GetInt("score");
        print(endScore);
    }
}
