using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EditObstacleView : MonoBehaviour
{
    #region Unity
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

    public void ShowFileManager()
    {
        InitFileManager();
    }
    #endregion

    public void InitFileManager()
    {
        FileManager.Show(Application.temporaryCachePath);
    }
}
