using UnityEditor;
using UnityEngine;


public class ClearUndo: EditorWindow
{
    [MenuItem("Edit/Clear undo")]
    public static void ClearLogCommand()
    {
        Undo.ClearAll();
        Debug.Log(Undo.GetCurrentGroup());
        Debug.Log(Undo.GetCurrentGroupName());
    }

    //    [MenuItem("Edit/Test", false, 1100)]
    //    public static void TestCommand()
    //    {

    //    }

    //    static string[] text;

    //    [MenuItem("Edit/Test", true, 1100)]
    //    public static bool TestCommandValidate()
    //    {
    //        return Selection.activeGameObject != null;
    //    }
}


public class ClearLog : EditorWindow
{
    [MenuItem("Edit/Clear log")]
    public static void ClearLogCommand()
    {
        UnityEngine.Debug.ClearDeveloperConsole();
    }
}
