using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ChooseMapView : MonoBehaviour
{
    #region Unity
    void Start()
    {
        LoadMaps();
    }

    void Update()
    {
        
    }

    #endregion

    #region PlayerActions

    public void AddPlayer()
    {
        Transform verticalLayout = GameObject.Find("(P) Players").transform.GetChild(0);
        var newRow = Instantiate(verticalLayout.GetChild(verticalLayout.childCount - 2).gameObject, verticalLayout) as GameObject;
        newRow.transform.SetSiblingIndex(verticalLayout.childCount - 2);
        verticalLayout.GetChild(verticalLayout.childCount - 3).gameObject.SetActive(true);
    }

    public void StartGame()
    {
        SessionSetup setup = GameObject.FindGameObjectWithTag("GameState").GetComponent<SessionSetup>();
        setup.playAreaSize = new Vector2Int(GetIntInputValue("(I) FieldX"), GetIntInputValue("(I) FieldY"));
        setup.piecesToWin = GetIntInputValue("(I) Pieces to win");

        setup.players.Clear();

        Transform verticalLayout = GameObject.Find("(P) Players").transform.GetChild(0);
        for (int i = 0; i < verticalLayout.childCount - 1; i++)
        {
            string name = verticalLayout.GetChild(i).Find("(I) Player Name").GetComponent<InputField>().text;
            int control = verticalLayout.GetChild(i).Find("(D) Control").GetComponent<Dropdown>().value;
            setup.players.Add(new Player(new MarkType(), control == 1, name));
        }

        TicTacToeGlobal.views.ActivateGameView();
    }

    public void Back()
    {
        TicTacToeGlobal.views.ActivateMainMenuView();
    }

    #endregion

    public void LoadMaps()
    {
        string mapsPath = Path.Combine(Application.persistentDataPath, "Maps");
        if (Directory.Exists(mapsPath))
        {
            foreach (var mapPath in Directory.GetFiles(mapsPath, "*.json"))
            {
                LoadMap(mapPath);
            }
        }
    }

    public void LoadMap(string mapPath)
    {

    }

    public static int GetIntInputValue(string editName)
    {
        GameObject go = GameObject.Find(editName);
        if (go != null)
        {
            Transform textChild = go.transform.Find("Text");
            if (textChild != null)
            {
                Text text = textChild.GetComponent<Text>();
                if (text != null)
                {
                    return System.Convert.ToInt32(text.text);
                }
                else
                {
                    throw new MalformedControlException(editName);
                }
            }
            else
            {
                throw new MalformedControlException(editName);
            }
        }
        else
        {
            throw new MissingControlException(editName);
        }
    }
}
