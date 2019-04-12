using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TicTacToePlayArea))]
[CanEditMultipleObjects]
public class TicTacToePlayAreaEditor : Editor
{
    SerializedProperty playableAreaSizeProp;
    SerializedProperty spacingProp;
    SerializedProperty backgroundPrefabProp;
    SerializedProperty cellPrefabProp;

    void FlushShit()
    {
        Debug.Log("Flush");
        Debug.Log(Undo.GetCurrentGroupName());
        Debug.Log(Undo.GetCurrentGroup());
    }

    void UndoRedo()
    {
        Debug.Log("UndoRedo");
    }

    void OnEnable()
    {
        Undo.undoRedoPerformed += UndoRedo;
        Undo.willFlushUndoRecord += FlushShit;


        // Setup the SerializedProperties.
        playableAreaSizeProp = serializedObject.FindProperty("playableAreaSize");
        spacingProp = serializedObject.FindProperty("spacing");
        backgroundPrefabProp = serializedObject.FindProperty("backgroundPrefab");
        cellPrefabProp = serializedObject.FindProperty("cellPrefab");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(playableAreaSizeProp);
        EditorGUILayout.PropertyField(spacingProp);
        EditorGUILayout.PropertyField(backgroundPrefabProp);
        EditorGUILayout.PropertyField(cellPrefabProp);
        if (EditorGUI.EndChangeCheck())
        {
            CreateCells();
        }

        serializedObject.ApplyModifiedProperties();
    }

    public void CreateCells()
    {
        Cell cell = Instantiate<Cell>((Cell)cellPrefabProp.objectReferenceValue, Vector3.zero, Quaternion.identity);

        Debug.Log(Undo.GetCurrentGroup());
        Debug.Log(Undo.GetCurrentGroupName());
        Undo.RegisterCreatedObjectUndo(cell.gameObject, "asdas");
        Debug.Log(Undo.GetCurrentGroup());
        Debug.Log(Undo.GetCurrentGroupName());

        //Debug.Log("changed");
        //var ttt = target as TicTacToePlayArea;

        //var bg = ttt.transform.GetChild(0);
        //var grid = ttt.transform.GetChild(1);

        //bg.transform.localScale = new Vector3(playableAreaProp.vector2IntValue.x * cellSizeProp.floatValue, playableAreaProp.vector2IntValue.y * cellSizeProp.floatValue, 1);
        //grid.GetComponent<SpriteRenderer>().size = new Vector2(playableAreaProp.vector2IntValue.x * cellSizeProp.floatValue, playableAreaProp.vector2IntValue.y * cellSizeProp.floatValue);
    }

}