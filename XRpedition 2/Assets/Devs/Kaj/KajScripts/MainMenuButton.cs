using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private string _GoScene;
    public void StartMenu()
    {
        SceneManager.LoadScene(_GoScene);
    }

    public void ExitMenu()
    {
            Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;      
#endif
    }
}
