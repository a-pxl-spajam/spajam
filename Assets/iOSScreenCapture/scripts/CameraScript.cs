using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class CameraScript : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void _PlaySystemShutterSound();

    [DllImport("__Internal")]
    private static extern void _SendTexture(byte[] textureByte, int length);

    [DllImport("__Internal")]
    private static extern void _RequestCameraPermission();

    [DllImport("__Internal")]
    private static extern void _RequestCameraRollPermission();

    [DllImport("__Internal")]
    private static extern int _HasCameraPermission();

    [DllImport("__Internal")]
    private static extern int _HasCameraRollPermission();

    [DllImport("__Internal")]
    private static extern void _GoToSettings();

    public static void PlaySystemShutterSound()
    {
        _PlaySystemShutterSound();
    }

    public static void SaveTexture(byte[] textureByte, int length)
    {
        _SendTexture(textureByte, length);
    }
    public static void RequestPermissions()
    {
        AVAuthorizationStatus avstatus = HasCameraPermission();
        PHAuthorizationStatus phstatus = HasCameraRollPermission();
        if (avstatus == AVAuthorizationStatus.NotDetermined)
        {
            _RequestCameraPermission();
        }
        if (phstatus == PHAuthorizationStatus.NotDetermined)
        {
            _RequestCameraRollPermission();
        }
    }
    //adapt Button
    public void RequestPermissions_forGUI()
    {
        RequestPermissions();
    }
    public static AVAuthorizationStatus HasCameraPermission()
    {
#if !UNITY_EDITOR
        return(AVAuthorizationStatus)Enum.ToObject(
                                    typeof(AVAuthorizationStatus),_HasCameraPermission());
#endif
        return AVAuthorizationStatus.Authorized;

    }
    public static PHAuthorizationStatus HasCameraRollPermission()
    {
#if !UNITY_EDITOR
        return (PHAuthorizationStatus)Enum.ToObject(
            typeof(PHAuthorizationStatus), HasCameraRollPermission());
#endif
        return PHAuthorizationStatus.Authorized;
    }

    public static void GoTOSetting()
    {
#if !UNITY_EDITOR
        _GoToSettings();
#endif
    }

    public void GoToSetting_forGUI()
    {
#if !UNITY_EDITOR
        _GoToSettings();
#endif
    }
}
