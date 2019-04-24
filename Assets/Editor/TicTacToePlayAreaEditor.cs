using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TicTacToePlayAreaData
{
    public Vector2Int playAreaSize;
    public float spacing;
    public SpriteRenderer bgObj;
    public Cell cellPrefab;
}

[CustomEditor(typeof(TicTacToePlayArea))]
[CanEditMultipleObjects]
[InitializeOnLoad]
public class TicTacToePlayAreaEditor : Editor
{
    static TicTacToePlayAreaEditor()
    {
        // prevents rewritting prevData when playmode is entered
        if (prevData == null)
        {
            prevData = new Dictionary<TicTacToePlayArea, TicTacToePlayAreaData>();
        }
    }

    public static Dictionary<TicTacToePlayArea, TicTacToePlayAreaData> prevData;

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
            if (prevBg != null)
            {
                prevBg.gameObject.DestroyChildrenImmediate();
            }
            CreateCells();
        }

        serializedObject.ApplyModifiedProperties();
    }

    public void CreateCells()
    {
        Debug.Log("changed");

        var ttt = target as TicTacToePlayArea;

        SpriteRenderer bg = (SpriteRenderer)bgObjProp.objectReferenceValue;
        Cell cellPrefab = (Cell)cellPrefabProp.objectReferenceValue;
        Vector2Int playAreaSize = playAreaSizeProp.vector2IntValue;
        float spacing = spacingProp.floatValue;

        //TicTacToePlayAreaData data = null;

        //// if we already edited this object before
        //if (prevData.TryGetValue(ttt, out data))
        //{
            //// remove all previous cells
            //if (data.bgObj)
            //{
            //    data.bgObj.gameObject.DestroyChildrenImmediate();
            //}

            // create new cells
            if (cellPrefab != null && bg != null && playAreaSize.x != 0 && playAreaSize.y != 0)
            {
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
                    }
                }
            }

            //if (data.bgObj != bg)
            //{
            //    data.bgObj = bg;
            //}

            //prevData.Remove(ttt);
        //}
        //// if we edit this object first time
        //else
        //{
        //    data = new TicTacToePlayAreaData();
        //    data.bgObj = bg;
        //    data.cellPrefab = cellPrefab;
        //    data.playAreaSize = playAreaSize;
        //    data.spacing = spacing;

        //    //if (bg != null)
        //    //{
        //    //    if (isPrefab(bg.gameObject))
        //    //    {

        //    //    }
        //    //}

        //    prevData.Add(ttt, data);
        //}
    }

    [MenuItem("MyMenu/Selection %g", false, 200)]
    public static void CheckPrefab()
    {
        Debug.Log(PrefabUtility.GetPrefabInstanceStatus(Selection.activeGameObject));
    }

    [MenuItem("MyMenu/Selection %g", true, 200)]
    public static bool CheckPrefabValidate()
    {
        return Selection.activeGameObject != null;
    }
}
