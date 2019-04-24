using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Govneco : System.Object
{
    public int p = 5;
    public Color c = Color.white;
}


[HelpURL("http://example.com/docs/MyComponent.html")]
public class Info : MonoBehaviour
{
    private int seconds;

    public Vector3 tests;
    [Header("Health Settings")]
    public Camera mainCam;

    public Govneco gg;

    [ContextMenuItem("asdfasdf", "DoWW")]
    [ContextMenuItem("!!", "DoWW2")]
    [ContextMenuItem("qqqqqqqq", "DoWW")]
    [ContextMenuItem("wwwwwwww", "DoWW2")]
    [ContextMenuItem("eeeeee", "DoWW")]
    [ContextMenuItem("rrrrrr", "DoWW2")]
    [ContextMenuItem("tttttttt", "DoWW")]
    [ContextMenuItem("yyyyyyyy", "DoWW2")]
    [ContextMenuItem("uuuuuuu", "DoWW")]
    [ContextMenuItem("iiiiiiii", "DoWW2")]
    [ContextMenuItem("ooooooo", "DoWW")]
    [ContextMenuItem("pppppppp", "DoWW2")]
    public bool pressed;

    [TextArea]
    public string q;

    public int mode = 0;

    [RuntimeInitializeOnLoadMethod]
    void DoShit()
    {
        Debug.Log("RuntimeInitializeOnLoadMethod");
    }

    [ContextMenu("!!!", false, 599)]
    void DoMsth()
    {
        Debug.Log("Hui");
    }

    void DoWW()
    {
        Debug.Log("Hui");
    }

    void DoWW2()
    {
        Debug.Log("2 Huia");
    }

    void Start()
    {
        seconds = 0;
        pressed = false;

        print("Compiled with " + GetDotNetCompiler());
        print("You are running with " + GetDotNetRuntime());

        ApplicationInfo();
        EditorApplicationInfo();
        ScreenInfo();
        DeviceInfo();
        AssetDatabaseInfo();

        EditorPrefs.SetBool("__govno", true);
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

    void EditorApplicationInfo()
    {
        print("======= Editor Application Info =======");
        print("EditorApplication.scriptingRuntimeVersion " + EditorApplication.scriptingRuntimeVersion);

        print("======= Editor Application Paths =======");

        print("EditorApplication.applicationContentsPath " + EditorApplication.applicationContentsPath);
        print("EditorApplication.applicationPath " + EditorApplication.applicationPath);

        print("======= Editor Application Status =======");

        print("EditorApplication.isCompiling " + EditorApplication.isCompiling);
        print("EditorApplication.isPaused " + EditorApplication.isPaused);
        print("EditorApplication.isPlaying " + EditorApplication.isPlaying);
        print("EditorApplication.isSceneDirty " + EditorApplication.isSceneDirty);
        print("EditorApplication.isTemporaryProject " + EditorApplication.isTemporaryProject);
        print("EditorApplication.isRemoteConnected " + EditorApplication.isRemoteConnected);
        print("EditorApplication.isUpdating " + EditorApplication.isUpdating);

        print("======= Editor Application Other =======");
        print("EditorApplication.timeSinceStartup " + EditorApplication.timeSinceStartup);
    }

    void AssetDatabaseInfo()
    {
        print("======= Asset Database Info =======");
        //AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(AssetDatabase.GUIDToAssetPath(guid)).GetInstanceID();
        
        string[] names = AssetDatabase.GetAllAssetBundleNames();
        print("AssetDatabase.GetAllAssetBundleNames (" + names.Length + "): ");
        foreach (var name in names)
        {
            print(name);
        }
        Debug.Log("AssetDatabase.GetCurrentCacheServerIp()" + AssetDatabase.GetCurrentCacheServerIp());
        Debug.Log("AssetDatabase.IsValidFolder()" + AssetDatabase.IsValidFolder("Assets"));
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

        SpriteRenderer r = GetComponent<SpriteRenderer>();
        //r.bounds.Get


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

    private string path = "Assets";
    private bool result = false;
    void OnGUI()
    {
        Debug.Log("Current detected event: " + Event.current);

        GUI.Label(new Rect(10, 10, 300, 20), Screen.fullScreen.ToString());
        GUI.Label(new Rect(10, 40, 300, 20), Screen.fullScreenMode.ToString());

        GUI.Label(new Rect(10, 70, 300, 20), pressed.ToString());

        GUI.Label(new Rect(10, 100, 300, 20), mainCam.aspect.ToString());

        GUI.Label(new Rect(10, 130, 300, 20), Application.consoleLogPath.ToString());

        GUI.Label(new Rect(10, 160, 300, 20), PlayerPrefs.GetInt("Screenmanager Resolution Width_h182942802").ToString());

        path = GUI.TextField(new Rect(10, 190, 300, 20), path);

        if (GUI.Button(new Rect(320, 190, 100, 20), "Button"))
        {
            result = AssetDatabase.IsValidFolder(path);
        }

        GUI.Label(new Rect(10, 220, 300, 20), result.ToString());

        
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
