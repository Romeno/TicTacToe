using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class RomenoExtensions
{
    #region Bounds Extenstions 
    public static Vector3 GetTopLeft(this Bounds b)
    {
        return new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z);
    }
    #endregion

    #region
    public static void DestroyChildrenImmediate(this GameObject go)
    {
        if (go != null)
        {
            while (go.transform.childCount > 0)
            {
                Object.DestroyImmediate(go.transform.GetChild(0).gameObject);
            }
        }
    }
    #endregion
}