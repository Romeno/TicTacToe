using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EditObstacleView : MonoBehaviour
{
    #region Unity
    void Start()
    {

    }

    void Update()
    {

    }

    void OnEnable()
    {
        //ShowFileManager();
    }
    #endregion

    #region PlayerActions
    public void SaveObstacle()
    {
        TicTacToeGlobal.views.ActivateEditObstacleView();
    }

    public void Back()
    {
        TicTacToeGlobal.views.ActivateDesignView();
    }
    #endregion
}
