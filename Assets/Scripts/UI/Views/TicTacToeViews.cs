using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeViews : MonoBehaviour
{
    public GameObject background;
    public GameObject logoView;
    public GameObject mainMenuView;
    public GameObject chooseMapView;
    public GameObject gameView;
    public GameObject designView;
    public GameObject editEnemyView;
    public GameObject editObstacleView;
    public GameObject settingsView;
    public GameObject fileManagerView;

    public float startTime;
    public bool started = false;

    void Awake()
    {
        background.SetActive(false);
        logoView.SetActive(false);
        mainMenuView.SetActive(false);
        chooseMapView.SetActive(false);
        gameView.SetActive(false);
        designView.SetActive(false);
        editEnemyView.SetActive(false);
        editObstacleView.SetActive(false);
        settingsView.SetActive(false);
        fileManagerView.SetActive(false);
    }

    void Start()
    {
        startTime = Time.time;

    }

    void Update()
    {
        if (Time.time - startTime > 1 && !started)
        {
            ActivateGameView();
            started = true;
        }
    }

    public void ActivateLogoView()
    {
        background.SetActive(false);

        logoView.SetActive(true);
        mainMenuView.SetActive(false);
        chooseMapView.SetActive(false);
        gameView.SetActive(false);
        designView.SetActive(false);
        editEnemyView.SetActive(false);
        editObstacleView.SetActive(false);
        settingsView.SetActive(false);
        fileManagerView.SetActive(false);
    }

    public void ActivateMainMenuView()
    {
        background.SetActive(true);
        TicTacToeGlobal.musicManager.SwitchToMainMenuTheme();

        logoView.SetActive(false);
        mainMenuView.SetActive(true);
        chooseMapView.SetActive(false);
        gameView.SetActive(false);
        designView.SetActive(false);
        editEnemyView.SetActive(false);
        editObstacleView.SetActive(false);
        settingsView.SetActive(false);
        fileManagerView.SetActive(false);
    }

    public void ActivateChooseMapView()
    {
        logoView.SetActive(false);
        mainMenuView.SetActive(false);
        chooseMapView.SetActive(true);
        gameView.SetActive(false);
        designView.SetActive(false);
        editEnemyView.SetActive(false);
        editObstacleView.SetActive(false);
        settingsView.SetActive(false);
        fileManagerView.SetActive(false);
    }

    public void ActivateGameView()
    {
        background.SetActive(false);
        TicTacToeGlobal.musicManager.SwitchToGameTheme();

        logoView.SetActive(false);
        mainMenuView.SetActive(false);
        chooseMapView.SetActive(false);
        gameView.SetActive(true);
        designView.SetActive(false);
        editEnemyView.SetActive(false);
        editObstacleView.SetActive(false);
        settingsView.SetActive(false);
        fileManagerView.SetActive(false);
    }

    public void ActivateDesignView()
    {
        logoView.SetActive(false);
        mainMenuView.SetActive(false);
        chooseMapView.SetActive(false);
        gameView.SetActive(false);
        designView.SetActive(true);
        editEnemyView.SetActive(false);
        editObstacleView.SetActive(false);
        settingsView.SetActive(false);
        fileManagerView.SetActive(false);
    }

    public void ActivateEditEnemyView()
    {
        logoView.SetActive(false);
        mainMenuView.SetActive(false);
        chooseMapView.SetActive(false);
        gameView.SetActive(false);
        designView.SetActive(false);
        editEnemyView.SetActive(true);
        editObstacleView.SetActive(false);
        settingsView.SetActive(false);
        fileManagerView.SetActive(false);
    }

    public void ActivateEditObstacleView()
    {
        logoView.SetActive(false);
        mainMenuView.SetActive(false);
        chooseMapView.SetActive(false);
        gameView.SetActive(false);
        designView.SetActive(false);
        editEnemyView.SetActive(false);
        editObstacleView.SetActive(true);
        settingsView.SetActive(false);
        fileManagerView.SetActive(false);
    }

    public void ActivateSettingsView()
    {
        logoView.SetActive(false);
        mainMenuView.SetActive(false);
        chooseMapView.SetActive(false);
        gameView.SetActive(false);
        designView.SetActive(false);
        editEnemyView.SetActive(false);
        editObstacleView.SetActive(false);
        settingsView.SetActive(true);
        fileManagerView.SetActive(false);
    }

    public void ActivateFileManagerView()
    {
        logoView.SetActive(false);
        mainMenuView.SetActive(false);
        chooseMapView.SetActive(false);
        gameView.SetActive(false);
        designView.SetActive(false);
        editEnemyView.SetActive(false);
        editObstacleView.SetActive(false);
        settingsView.SetActive(false);
        fileManagerView.SetActive(true);
    }

    public void ShowInGameMenuModal(bool show)
    {

    }
}
