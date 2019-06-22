using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;

public class ScreenShot : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SavaToAlbum(string path);
    IEnumerator SaveToCameraroll(string path)
    {
        while (true)
        {
            if (File.Exists(path)) break;

            yield return null;
        }
        SavaToAlbum(path);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
#if UNITY_EDITOR
#else
            string filename="test.png";
            string path = Application.persistentDataPath+"/"+filename;

            File.Delete(path);

            ScreenCapture.CaptureScreenshot(filename);
            StartCoroutine(SaveToCameraroll(path));
#endif
        }
    }
}

