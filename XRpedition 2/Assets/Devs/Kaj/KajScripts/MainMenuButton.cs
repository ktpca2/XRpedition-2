using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartMenu()
    {
        SceneManager.LoadScene("KajScene");
    }

    public void ExitMenu()
    {
            Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;      
#endif
    }
}
