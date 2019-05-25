using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesignView : MonoBehaviour
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
    public void EditEnemy()
    {
        TicTacToeGlobal.views.ActivateEditEnemyView();
    }

    public void EditObstacle()
    {
        TicTacToeGlobal.views.ActivateEditObstacleView();
    }

    public void SaveMap()
    {
        TicTacToeGlobal.views.ActivateEditObstacleView();
    }

    public void PlayMap()
    {
        TicTacToeGlobal.views.ActivateGameView();
    }

    public void Back()
    {
        TicTacToeGlobal.views.ActivateMainMenuView();
    }

    public void AddPlayer()
    {
        Transform verticalLayout = GameObject.Find("(P) Map Player Preset").transform;
        var newRow = Instantiate(verticalLayout.GetChild(verticalLayout.childCount - 2).gameObject, verticalLayout) as GameObject;
        newRow.transform.SetSiblingIndex(verticalLayout.childCount - 2);
        verticalLayout.GetChild(verticalLayout.childCount - 3).gameObject.SetActive(true);
    }

    public void RemovePlayer()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject);
        Object.Destroy(EventSystem.current.currentSelectedGameObject.transform.parent.gameObject);
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

    public static void ImportAssetPressed()
    {
        FileManager.ImportAssetPressed();
    }
}
