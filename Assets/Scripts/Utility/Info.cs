using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    private int seconds;
    public Camera mainCam;

    public bool pressed;

    string q;
    int mode = 0;

    void Start()
    {
        seconds = 0;
        pressed = false;

        print("Compiled with " + GetDotNetCompiler());
        print("You are running with " + GetDotNetRuntime());

        ApplicationInfo();
        ScreenInfo();
        DeviceInfo();
    }

    #region Info UselessShit
    public string GetDotNetCompiler()
    {
#if __MonoCS__
        return "Mono compiler";
#else
        return "Something else";
#endif
    }

    public string GetDotNetRuntime()
    {
        System.Type t = System.Type.GetType("Mono.Runtime");
        if (t != null)
            return "Mono VM";
        else
            return "Something else";
    }

    #endregion

    #region Info SystemInfo
    void ApplicationInfo()
    {
        print("======= Application Info =======");

        print("Application.isConsolePlatform " + Application.isConsolePlatform);
        print("Application.isEditor " + Application.isEditor);
        print("Application.platform " + Application.platform);

        print("Application.consoleLogPath " + Application.consoleLogPath);
        print("Application.dataPath " + Application.dataPath);
        print("Application.persistentDataPath " + Application.persistentDataPath);
        print("Application.temporaryCachePath " + Application.temporaryCachePath);

        print("Application.absoluteURL " + Application.absoluteURL);
        print("Application.backgroundLoadingPriority " + Application.backgroundLoadingPriority);
        print("Application.internetReachability " + Application.internetReachability);
        print("Application.systemLanguage " + Application.systemLanguage);
        print("Application.sandboxType " + Application.sandboxType);

        print("Application.targetFrameRate " + Application.targetFrameRate);

        print("Application.productName " + Application.productName);
        print("Application.version " + Application.version);
        print("Application.unityVersion " + Application.unityVersion);
        print("Application.installMode " + Application.installMode);
        print("Application.buildGUID " + Application.buildGUID);
        print("Application.installerName " + Application.installerName);
        print("Application.installMode " + Application.installMode);
        print("Application.cloudProjectId " + Application.cloudProjectId);
        print("Application.identifier " + Application.identifier);

        print("Application.runInBackground " + Application.runInBackground);
    }

    void ScreenInfo()
    {
        print("======= Screen Info =======");

        //Debug.Log(Screen.orientation);
        //Debug.Log(Screen.height);
        //Debug.Log(Screen.width);
        //Debug.Log("Resolutions");
        //foreach (var r in Screen.resolutions)
        //{
        //    Debug.Log(r);
        //}

        //Debug.Log(Screen.safeArea);
        //Debug.Log(Screen.currentResolution);

        print("Camera.aspect = " + mainCam.aspect);

        print("Screen.fullScreen = " + Screen.fullScreen);
        print("Screen.fullScreenMode = " + Screen.fullScreenMode);
    }

    void DeviceInfo()
    {
        print("======= Device Info =======");
        foreach (var device in WebCamTexture.devices)
        {
            print("Webcam Name: " + device.name);
        }

        foreach (var device in Microphone.devices)
        {
            print("Microphone Name: " + device);
        }
    }
    #endregion

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            print(mainCam.ScreenToWorldPoint(Input.mousePosition));
        }

        //pressed = false;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    pressed = true;
        //    //Screen.fullScreen = !Screen.fullScreen;

        //    if (mode == 4)
        //    {
        //        mode = 0;
        //    }
        //    Screen.fullScreenMode = (FullScreenMode)mode;
        //    mode++;
        //    //float asp = Random.Range(0.0f, 1.0f);
        //    //Debug.Log(asp);
        //    //mainCam.aspect = asp;
        //}

        //if ((int)Time.time > seconds)
        //{
        //    seconds += 1;
        //    Debug.Log(Screen.fullScreen);
        //    Debug.Log(Screen.fullScreenMode);

        //    //Debug.Log(Screen.orientation);
        //    //Debug.Log(Screen.safeArea);
        //    //Debug.Log(Time.time);
        //}

        print("Frame " + Time.frameCount);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 20), Screen.fullScreen.ToString());
        GUI.Label(new Rect(10, 40, 300, 20), Screen.fullScreenMode.ToString());

        GUI.Label(new Rect(10, 70, 300, 20), pressed.ToString());

        GUI.Label(new Rect(10, 100, 300, 20), mainCam.aspect.ToString());

        GUI.Label(new Rect(10, 130, 300, 20), Application.consoleLogPath.ToString());

        GUI.Label(new Rect(10, 160, 300, 20), PlayerPrefs.GetInt("Screenmanager Resolution Width_h182942802").ToString());

        //GUI.Label(new Rect(10, 40, 300, 20), Screen.orientation.ToString());
        //GUI.Label(new Rect(10, 70, 300, 20), Screen.safeArea.ToString());

        //if (Screen.resolutions.Length != 0)
        //{
        //    GUI.Box(new Rect(10, 100, 300, 30 * Screen.resolutions.Length), "Resolutions");
        //    for (int i = 0; i < Screen.resolutions.Length; i++)
        //    {
        //        GUI.Label(new Rect(10, 110 + 30 * i, 300, 20), Screen.resolutions[i].ToString());
        //    }
        //}
    }
}
