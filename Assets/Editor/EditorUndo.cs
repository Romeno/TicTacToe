using UnityEditor;
using UnityEngine;

//[InitializeOnLoad]
[CustomEditor(typeof(TicTacToe))]
public class EditorUndo : Editor
{
    //static EditorUndo()
    //{
    //    if (!EditorApplication.isPlayingOrWillChangePlaymode)
    //    {
    //        Undo.undoRedoPerformed += UndoRedo;
    //        Undo.willFlushUndoRecord += FlushShit;
    //    }
    //}

    //public static void FlushShit()
    //{
    //    Debug.Log("Flush");
    //    Debug.Log(Undo.GetCurrentGroupName());
    //    Debug.Log(Undo.GetCurrentGroup());
    //}

    //public static void UndoRedo()
    //{
    //    Debug.Log("UndoRedo");
    //}

    //[MenuItem("MyMenu/Clear undo", false, 100)]
    //public static void ClearUndoCommand()
    //{
    //    Undo.ClearAll();
    //    Debug.Log(Undo.GetCurrentGroup());
    //    Debug.Log(Undo.GetCurrentGroupName());
    //}

    //[MenuItem("MyMenu/Create undoable object", false, 101)]
    //public static void CreateUndoableObjectCommand()
    //{

    //}

    //[MenuItem("MyMenu/UndoWindow")]
    //public static void ShowWindow()
    //{
    //    //EditorWindow.GetWindow<EditorUndo>().Show();
    //}

    //public override void OnInspectorGUI()
    //{
    //    DrawDefaultInspector();

    //    GUILayout.Label(Undo.GetCurrentGroup().ToString());
    //}

    public void OnSceneGUI()
    {
        Debug.Log("OnSceneGUI");

        Handles.BeginGUI();

        GUILayout.Label(Undo.GetCurrentGroup().ToString());

        Handles.EndGUI();
    }

}