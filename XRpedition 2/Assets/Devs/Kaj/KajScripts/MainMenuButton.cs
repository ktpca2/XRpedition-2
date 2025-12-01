using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private string GoScene;
    public void StartMenu()
    {
        SceneManager.LoadScene(GoScene);
    }

    public void ExitMenu()
    {
            Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;      
#endif
    }
}
