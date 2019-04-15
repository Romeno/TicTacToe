using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorCustomWindow : EditorWindow
{
    [MenuItem("MyMenu/CustomWindow", false, 60)]
    public static void ShowWindow()
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(EditorCustomWindow));
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 20), Screen.fullScreen.ToString());
        GUI.Label(new Rect(10, 40, 300, 20), Screen.fullScreenMode.ToString());

        GUI.Label(new Rect(10, 130, 300, 20), Application.consoleLogPath.ToString());

        GUI.Label(new Rect(10, 160, 300, 20), PlayerPrefs.GetInt("Screenmanager Resolution Width_h182942802").ToString());
    }
}
