using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor;

public class MainMenuView : MonoBehaviour
{
    #region Unity
    void Start()
    {

    }

    void Update()
    {
        var a = GetComponent<Animator>();
        var stateInfo = a.GetCurrentAnimatorStateInfo(0);
        var animTime = stateInfo.normalizedTime;

        if (animTime > 0.75f && !a.IsInTransition(0))
        {
            if (stateInfo.IsName("MainMenuGoToPlay"))
            {
                TicTacToeGlobal.views.chooseMapView.SetActive(true);
            }
            else if (stateInfo.IsName("MainMenuGoToDesign"))
            {
                TicTacToeGlobal.views.ActivateDesignView();
            }
            else if (stateInfo.IsName("MainMenuGoToSettings"))
            {
                TicTacToeGlobal.views.ActivateSettingsView();
            }
        }

        if (animTime > 1.0f && !a.IsInTransition(0))
        {
            if (stateInfo.IsName("MainMenuQuit"))
            {
                ApplicationUtil.Quit();
            }
        }

        if (animTime > 1.75f && !a.IsInTransition(0))
        {
            if (stateInfo.IsName("MainMenuGoToPlay") || 
                stateInfo.IsName("MainMenuGoToDesign") || 
                stateInfo.IsName("MainMenuGoToSettings"))
            {
                TicTacToeGlobal.views.mainMenuView.SetActive(false);
            }
        }
    }
    #endregion

    #region PlayerActions
    public void Play()
    {
        var a = GetComponent<Animator>();

        a.SetTrigger("Play");
    }

    public void Design()
    {
        var a = GetComponent<Animator>();

        a.SetTrigger("Design");
    }

    public void Settings()
    {
        var a = GetComponent<Animator>();

        a.SetTrigger("Settings");
    }

    public void Quit()
    {
        var a = GetComponent<Animator>();

        a.SetTrigger("Quit");
    }
    #endregion
}
