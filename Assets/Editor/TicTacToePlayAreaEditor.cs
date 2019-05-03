using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TicTacToePlayArea))]
[CanEditMultipleObjects]
public class TicTacToePlayAreaEditor : Editor
{
    SerializedProperty playAreaSizeProp;
    SerializedProperty spacingProp;
    SerializedProperty bgObjProp;
    SerializedProperty cellPrefabProp;

    void OnEnable()
    {
        // Setup the SerializedProperties.
        playAreaSizeProp = serializedObject.FindProperty("playAreaSize");
        spacingProp = serializedObject.FindProperty("spacing");
        bgObjProp = serializedObject.FindProperty("bgObj");
        cellPrefabProp = serializedObject.FindProperty("cellPrefab");
    }

    public override void OnInspectorGUI()
    {
        SpriteRenderer prevBg = (SpriteRenderer)bgObjProp.objectReferenceValue;

        serializedObject.Update();

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(playAreaSizeProp);
        EditorGUILayout.PropertyField(spacingProp);
        EditorGUILayout.PropertyField(bgObjProp);
        EditorGUILayout.PropertyField(cellPrefabProp);
        if (EditorGUI.EndChangeCheck())
        {
            CreateCells(prevBg);
        }

        serializedObject.ApplyModifiedProperties();
    }

    public void CreateCells(SpriteRenderer prevBg)
    {
        var ttt = target as TicTacToePlayArea;

        SpriteRenderer bg = (SpriteRenderer)bgObjProp.objectReferenceValue;
        Cell cellPrefab = (Cell)cellPrefabProp.objectReferenceValue;
        Vector2Int playAreaSize = playAreaSizeProp.vector2IntValue;
        float spacing = spacingProp.floatValue;

        // if can create new cells
        if (cellPrefab != null && bg != null && playAreaSize.x != 0 && playAreaSize.y != 0)
        {
            int undoGroup = Undo.GetCurrentGroup();
            if (prevBg != null)
            {
                prevBg.gameObject.DestroyChildrenImmediate(true);
            }

            SpriteRenderer cellRend = cellPrefab.GetComponent<SpriteRenderer>();
            Bounds cellBounds = cellRend.bounds;
            Bounds bgBounds = bg.bounds;
            Vector3 pos;
            float fieldWidth = spacing * (playAreaSize.x - 1) + cellBounds.size.x * playAreaSize.x;
            float fieldHeight = spacing * (playAreaSize.y - 1) + cellBounds.size.y * playAreaSize.y;

            for (int i = 0; i < playAreaSize.y; i++)
            {
                for (int j = 0; j < playAreaSize.x; j++)
                {
                    pos = new Vector3(
                        bgBounds.center.x - fieldWidth / 2 + cellBounds.extents.x + j * (spacing + cellBounds.size.x),
                        bgBounds.center.y + fieldHeight / 2 - cellBounds.extents.y - i * (spacing + cellBounds.size.y),
                        bgBounds.center.z);

                    Cell newCell = (Cell)(PrefabUtility.InstantiatePrefab(cellPrefab));
                    newCell.transform.SetParent(bg.transform);
                    newCell.transform.position = pos;
                    Undo.RegisterCreatedObjectUndo(newCell.gameObject, "TicTacToe Field Size");
                }
            }
            Undo.CollapseUndoOperations(undoGroup);
        }
    }
}
