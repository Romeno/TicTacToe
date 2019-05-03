using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class RomenoExtensions
{
    #region Bounds Extenstions 

    public static Vector3 GetTopLeft(this Bounds b)
    {
        return new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z);
    }

    public static Vector3 GetBottomRight(this Bounds b)
    {
        return new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z);
    }

    #endregion

    #region Array Extenstions 

    public static T[] Fill<T>(this T[] arr, T value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = value;
        }

        return arr;
    }

    #endregion

    #region GameObject Extenstions 

    public static void DestroyChildrenImmediate(this GameObject go
#if UNITY_EDITOR
        , bool undoable
#endif
        )
    {
        if (go != null)
        {
            while (go.transform.childCount > 0)
            {
#if UNITY_EDITOR
                if (undoable)
                {
                    Undo.DestroyObjectImmediate(go.transform.GetChild(0).gameObject);
                }
                else
                {
#endif
                    Object.DestroyImmediate(go.transform.GetChild(0).gameObject);
#if UNITY_EDITOR
                }
#endif
            }
        }
    }

    #endregion
}
