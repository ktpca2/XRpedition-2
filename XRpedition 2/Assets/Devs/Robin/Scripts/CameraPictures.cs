using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class CameraPictures : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;
    [SerializeField] private RenderTexture rt;

    public void TakePicture(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(CaptureCamera());
        }
    }

    private IEnumerator CaptureCamera()
    {
        yield return new WaitForEndOfFrame();

        targetCamera.targetTexture = rt;
        
        targetCamera.Render();

        RenderTexture.active = rt;
        Texture2D screenshot = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false);
        screenshot.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        screenshot.Apply();

        targetCamera.targetTexture = null;
        RenderTexture.active = null;

        byte[] bytes = screenshot.EncodeToPNG();
        string folderPath = "Assets/Screenshots/";
        Directory.CreateDirectory(folderPath);

        string screenshotName = "Screenshot_" +
        System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png";

        File.WriteAllBytes(Path.Combine(folderPath, screenshotName), bytes);
        Debug.Log("Saved: " + folderPath + screenshotName);
    }
}
