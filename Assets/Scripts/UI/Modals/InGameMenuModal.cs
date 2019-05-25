using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuModal : MonoBehaviour
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
    #endregion

    #region PlayerActions

    public void Resume()
    {
        TicTacToeGlobal.views.ShowInGameMenuModal(false);
    }

    public void Restart()
    {
        
    }

    public void MainMenu()
    {
        TicTacToeGlobal.views.ActivateMainMenuView();
    }

    public void Exit()
    {
        ApplicationUtil.Quit();
    }

    #endregion
}
