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
        Buttons[0].interactable = false;
        Buttons[1].interactable = false;
        StartCoroutine(DisableMenu());
    }

    IEnumerator DisableMenu()
    {
        yield return new WaitForSeconds(Intro.length);
        Buttons[0].interactable = true;
        Buttons[1].interactable = true;
    }
}
