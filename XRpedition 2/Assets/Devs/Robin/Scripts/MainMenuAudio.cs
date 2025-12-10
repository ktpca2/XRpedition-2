using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAudio : MonoBehaviour
{
    [SerializeField] AudioClip Intro;
    [SerializeField] private Button[] Buttons;
    
    void Start()
    {
        foreach (Button button in Buttons)
        {
            button.interactable = false;
        }
        StartCoroutine(DisableMenu());
    }

    IEnumerator DisableMenu()
    {
        yield return new WaitForSeconds(Intro.length);
        foreach (Button button in Buttons)
        {
            button.interactable = true;
        }
    }
}
