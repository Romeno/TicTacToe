using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(TicTacToePlayArea))]
public class TicTacToe : MonoBehaviour
{
    public MarkDatabase markDB;

    public GameObject gameOverObject;

    [HideInInspector]
    public int score;

    [HideInInspector]
    public int playerNum;

    [HideInInspector]
    public Player[] players;

    private Cell[,] mathModel;
    private ObjectPool<Mark, MarkType> markPool;

    private int playerTurn;
    private bool spawning;
    private bool gameOver;
    private bool moving;

    private Vector2Int fieldSize;
    //public float cellSize;

    #region TicTacToe Initialization

    void Start()
    {
        fieldSize = GetComponent<TicTacToePlayArea>().playableAreaSize;
        //cellSize = GetComponent<TicTacToePlayArea>().cellSize;

        mathModel = new Cell[fieldSize.y, fieldSize.x];

        markPool = new ObjectPool<Mark, MarkType>();

        NewGame();
    }

    void NewGame()
    {
        CreateField();

        playerTurn = 0;
        spawning = false;
        gameOver = false;

        score = 0;
    }

    void CreateField()
    {
        //Bounds pos = backgroundPrefab.GetComponent<SpriteRenderer>().bounds;

        //for (int i = 0; i < fieldSize.y; i++)
        //{
        //    for (int j = 0; j < fieldSize.x; j++)
        //    {
        //        if (mathModel[i, j] == null)
        //        {
        //            mathModel[i, j] = Instantiate<Cell>(cellPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        //        }

        //        if (mathModel[i, j].mark != null)
        //        {
        //            markPool.DeleteObject(mathModel[i, j].mark);
        //            mathModel[i, j].mark = null;
        //        }
        //    }
        //}

    }
    #endregion

    #region TicTacToe Update

    void Update()
    {
        if (CheckGameOver())
        {
            GameOverState();
        }
        else
        {
            GameState();
        }
    }

    void GameState()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 pixelPos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pixelPos);
            //Instantiate(cellPrefab, new Vector3(worldPos.x, worldPos.y, 0), Quaternion.identity);
        }
    }

    void MoveNumbers1()
    {

    }

    bool CheckGameOver()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            return true;
        }

        //TODO: not implemented
        return false;
    }

    void GameOverState()
    {
        Animator a = gameOverObject.transform.GetChild(0).GetComponent<Animator>();
        if (!gameOver)
        {
            gameOverObject.SetActive(true);
            gameOver = true;
        }
        else
        {
            if (a.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !a.IsInTransition(0))
            {
                if (Input.anyKeyDown)
                {
                    gameOverObject.SetActive(false);
                    NewGame();
                }
            }
        }
    }

    #endregion

    #region TicTacToe Math

    Vector3 MathModelPos2GlobalPos(int x, int y)
    {
        return Vector3.zero;
        //return new Vector3(x * cellSize - fieldSize.x + cellSize / 2, -y * cellSize + fieldSize.y - cellSize / 2, 0);
    }

    #endregion

    #region TicTacToe Utility

    Mark NewMark(int playerNum)
    {
        return markPool.NewObject(players[playerNum].markType, GameObject.Find("Field").transform);
    }

    void DeleteMark(Mark mark)
    {
        markPool.DeleteObject(mark);
    }

    #endregion
}
