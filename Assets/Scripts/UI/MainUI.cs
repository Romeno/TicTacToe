using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor;

public class MainUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("Start called " + Time.time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        Debug.Log("Load level");
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Debug.Log("Quit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
