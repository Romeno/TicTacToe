using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor;

public class GameView : MonoBehaviour
{
    #region Unity
    void Start()
    {

    }

    void Update()
    {

    }
    #endregion

    #region PlayerActions

    public void Quit()
    {
        ApplicationUtil.Quit();
    }

    #endregion
}
