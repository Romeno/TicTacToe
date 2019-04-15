using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class EditModeShit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("shit start");

        StartCoroutine(Cacaha());

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("!!Update");

        //EditorUndo w = EditorWindow.GetWindow<EditorUndo>();

        //if (w != null)
        //{
        //    w.Repaint();
        //}
    }

    IEnumerator Cacaha()
    {
        Debug.Log("Cacaha started");
        yield return 10;
        Debug.Log("Cacaha finished");
    }
}
