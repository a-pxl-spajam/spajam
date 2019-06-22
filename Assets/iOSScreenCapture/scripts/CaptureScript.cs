using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CaptureScript : MonoBehaviour
{
    public UnityEvent OnCompleteCapture;
    public UnityEvent OnFailCapture;

    public void Execute()
    {
#if UNITY_EDITORx
        PHAuthorizationStatus phstatus = (PHAuthorizationStatus)Enum.ToObject(
            typeof(PHAuthorizationStatus), CameraScript.HasCameraRollPermission());
        CameraScript.PlaySystemShutterSound();
        if (phstatus == PHAuthorizationStatus.Authorized)
        {
            Handheld.SetActivityIndicatorStyle(UnityEngine.iOS.ActivityIndicatorStyle.Gray);
            Handheld.StartActivityIndicator();
            StartCoroutine(_CapturesScreenShot());
        }
        else
        {
            OnFailCapture.Invoke();
        }
#endif
    }

    private IEnumerator _CaptureScreenShot()
    {
        //canvasGroup.alpha=0;
        yield return new WaitForEndOfFrame();
        var width = Screen.width;
        var height = Screen.height;
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        byte[] screenshot = tex.EncodeToPNG();

        CameraScript.SaveTexture(screenshot, screenshot.Length);
        //canvasGroup.alpha=1;
    }

    void DidImageWriteToAlbum(string errorDescription)
    {
        Handheld.StopActivityIndicator();
        if (string.IsNullOrEmpty(errorDescription))
        {
            OnCompleteCapture.Invoke();
        }
        else
        {
            OnFailCapture.Invoke();
        }
    }
}
