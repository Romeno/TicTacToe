using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class EditorInit
{
    static EditorInit()
    {
        if (!EditorApplication.isPlayingOrWillChangePlaymode)
        {
            
        }
    }
}
