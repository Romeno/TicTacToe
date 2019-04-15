using UnityEditor;
using UnityEngine;

public class EditorLog
{
    [MenuItem("MyMenu/Clear log", false, 80)]
    public static void ClearLogCommand()
    {
        UnityEngine.Debug.ClearDeveloperConsole();
    }
}
