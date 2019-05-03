using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public enum GameState
{
    Game,
    Win,
    Lose,
    Draw,
    StopAtOnce
}

[RequireComponent(typeof(TicTacToePlayArea))]
public class TicTacToe : MonoBehaviour
{
    public MarkDatabase markDB;

    public GameObject gameOverObject;

    public GameObject background;

    [HideInInspector]
    public int score;

    [HideInInspector]
    public int playerNum;

    public Cell[,] mathModel;
    private ObjectPool<Mark, MarkType> markPool;

    private Player[] players;

    private int playerTurn;
    private bool spawning;
    private bool gameOver;
    private bool moving;

    private int freeCells;
    private int piecesToWin;

    private Vector2Int fieldSize;
    //public float cellSize;

    private int[] marksByDirection;
    private bool[] shouldMoveDirection;

    public GameState state;

    #region TicTacToe Initialization

    void Start()
    {
        fieldSize = GetComponent<TicTacToePlayArea>().playAreaSize;
        //cellSize = GetComponent<TicTacToePlayArea>().cellSize;

        mathModel = new Cell[fieldSize.y, fieldSize.x];

        markPool = new ObjectPool<Mark, MarkType>();

        for (int  i = 0; i < background.transform.childCount; i++)
        {
            mathModel[(int)(i / fieldSize.y), i % fieldSize.x] = background.transform.GetChild(i).GetComponent<Cell>();
        }

        // load all marks
        GameObject[] markPrefabs = Resources.LoadAll<GameObject>("Marks/Prefabs");

        MarkType mark1 = new MarkType();
        mark1.id = 0;
        mark1.objectPrefab = markPrefabs[0];

        MarkType mark2 = new MarkType();
        mark2.id = 1;
        mark2.objectPrefab = markPrefabs[1];

        players = new Player[2]
        {
            new Player(mark1, false, "Romeno"),
            new Player(mark2, true, "Computer")
        };

        freeCells = fieldSize.x * fieldSize.y;

        NewGame();

        playerTurn = 0;

        piecesToWin = 3;

        marksByDirection = new int[4];
        shouldMoveDirection = new bool[8];

        state = GameState.Game;
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

    public void RemoveMark(int x, int y)
    {
        Object.Destroy(mathModel[y, x].mark.go);
        mathModel[y, x].mark = null;
    }

    public void RemoveMark(Cell c)
    {
        Object.Destroy(c.mark.go);
        c.mark = null;
    }

    #endregion

    #region TicTacToe Update

    int attacks = 0;
    void Update()
    {
        if (CheckGameOver())
        {
            state = GameState.StopAtOnce;
        }

        switch (state)
        {
            case GameState.Game:
                GameStateLogic();
                break;
            case GameState.Win:
                WinStateLogic();
                break;
            case GameState.Lose:
                LoseStateLogic();
                break;
            case GameState.Draw:
                DrawStateLogic();
                break;
            case GameState.StopAtOnce:
                break;
            default:
                Debug.Log("Unknown game state " + state);
                break;
        }
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

    void GameStateLogic()
    {
        if (freeCells == 0)
        {
            state = GameState.Draw;
            return;
        }

        if (players[playerTurn].ai)
        {
            int aiMove = Random.Range(0, freeCells);
            int i = 0;
            for (int j = 0; i < fieldSize.x * fieldSize.y; i++)
            {
                Mark m = mathModel[(int)(i / fieldSize.y), i % fieldSize.x].mark;
                if (m == null)
                {
                    if (j == aiMove)
                    {
                        m = new Mark();
                        Transform cellTrans = background.transform.GetChild(i);
                        m.go = Instantiate(players[playerTurn].markType.objectPrefab, cellTrans.position, Quaternion.identity, cellTrans);
                        m.type = players[playerTurn].markType;
                        mathModel[(int)(i / fieldSize.y), i % fieldSize.x].mark = m;
                        freeCells--;
                        break;
                    }
                    j++;
                }
            }

            // check win 
            if (CheckWin(i % fieldSize.x, (int)(i / fieldSize.y)))
            {
                state = GameState.Lose;
            }

            playerTurn++;
            if (playerTurn >= players.Length)
            {
                playerTurn = 0;
            }
        }

        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Vector3 pixelPos = Input.mousePosition;
        //    Vector3 worldPos = Camera.main.ScreenToWorldPoint(pixelPos);
        //    //Instantiate(cellPrefab, new Vector3(worldPos.x, worldPos.y, 0), Quaternion.identity);
        //}
    }

    void WinStateLogic()
    {
        Animator a = gameOverObject.transform.GetChild(0).GetComponent<Animator>();
        if (!gameOver)
        {
            gameOverObject.SetActive(true);
            gameOverObject.transform.GetChild(0).GetComponent<Text>().text = "You Win!";
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

    void LoseStateLogic()
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

    void DrawStateLogic()
    {
        Animator a = gameOverObject.transform.GetChild(0).GetComponent<Animator>();
        if (!gameOver)
        {
            gameOverObject.SetActive(true);
            gameOverObject.transform.GetChild(0).GetComponent<Text>().text = "It is draw! Nobody wins!";
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

    public void CellClicked(GameObject cell)
    {
        if (playerTurn == 0)
        {
            int index = cell.transform.GetSiblingIndex();

            Cell c = mathModel[(int)(index / fieldSize.y), index % fieldSize.x];

            if (c.canPlaceMark)
            {
                Mark m = c.mark;
                if (m != null)
                {
                    GetComponent<AudioSource>().Play();
                    return;
                }

                freeCells--;

                m = new Mark();
                m.go = Instantiate(players[playerTurn].markType.objectPrefab, cell.transform.position, Quaternion.identity, cell.transform);
                m.type = players[playerTurn].markType;
                mathModel[(int)(index / fieldSize.y), index % fieldSize.x].mark = m;

                // check win 
                if (CheckWin(index % fieldSize.x, (int)(index / fieldSize.y)))
                {
                    state = GameState.Win;
                }

                playerTurn++;
                if (playerTurn >= players.Length)
                {
                    playerTurn = 0;
                }
            }
            else
            {
                GetComponent<AudioSource>().Play();
                return;
            }
        }
    }

    public bool CheckWin(int lastMoveX, int lastMoveY)
    {
        int i = 1;
        marksByDirection.Fill(0);
        shouldMoveDirection.Fill(true);

        MarkType curPlayerMarkType = players[playerTurn].markType;
        while (i <= piecesToWin)
        {
            // top
            if (lastMoveY - i >= 0 && shouldMoveDirection[0])
            {
                if (mathModel[lastMoveY - i, lastMoveX]?.mark?.type == curPlayerMarkType)
                {
                    marksByDirection[0]++;
                    if (marksByDirection[0] >= piecesToWin - 1)
                    {
                        return true;
                    }
                }
                else
                {
                    shouldMoveDirection[0] = false;
                }
            }
            else
            {
                shouldMoveDirection[0] = false;
            }

            // top left
            if (lastMoveX - i >= 0 && lastMoveY - i >= 0 && shouldMoveDirection[1])
            {
                if (mathModel[lastMoveY - i, lastMoveX - i]?.mark?.type == curPlayerMarkType)
                {
                    marksByDirection[1]++;
                    if (marksByDirection[1] >= piecesToWin - 1)
                    {
                        return true;
                    }
                }
                else
                {
                    shouldMoveDirection[1] = false;
                }
            }
            else
            {
                shouldMoveDirection[1] = false;
            }

            // left
            if (lastMoveX - i >= 0 && shouldMoveDirection[2])
            {
                if (mathModel[lastMoveY, lastMoveX - i]?.mark?.type == curPlayerMarkType)
                {
                    marksByDirection[2]++;
                    if (marksByDirection[2] >= piecesToWin - 1)
                    {
                        return true;
                    }
                }
                else
                {
                    shouldMoveDirection[2] = false;
                }
            }
            else
            {
                shouldMoveDirection[2] = false;
            }

            // bottom left
            if (lastMoveX - i >= 0 && lastMoveY + i < fieldSize.y && shouldMoveDirection[3])
            {
                if (mathModel[lastMoveY + i, lastMoveX - i]?.mark?.type == curPlayerMarkType)
                {
                    marksByDirection[3]++;
                    if (marksByDirection[3] >= piecesToWin - 1)
                    {
                        return true;
                    }
                }
                else
                {
                    shouldMoveDirection[3] = false;
                }
            }
            else
            {
                shouldMoveDirection[3] = false;
            }

            // bottom
            if (lastMoveY + i < fieldSize.y && shouldMoveDirection[4])
            {
                if (mathModel[lastMoveY + i, lastMoveX]?.mark?.type == curPlayerMarkType)
                {
                    marksByDirection[0]++;
                    if (marksByDirection[0] >= piecesToWin - 1)
                    {
                        return true;
                    }
                }
                else
                {
                    shouldMoveDirection[4] = false;
                }
            }
            else
            {
                shouldMoveDirection[4] = false;
            }

            // bottom right
            if (lastMoveX + i < fieldSize.x && lastMoveY + i < fieldSize.y && shouldMoveDirection[5])
            {
                if (mathModel[lastMoveY + i, lastMoveX + i]?.mark?.type == curPlayerMarkType)
                {
                    marksByDirection[1]++;
                    if (marksByDirection[1] >= piecesToWin - 1)
                    {
                        return true;
                    }
                }
                else
                {
                    shouldMoveDirection[5] = false;
                }
            }
            else
            {
                shouldMoveDirection[5] = false;
            }

            // right
            if (lastMoveX + i < fieldSize.x && shouldMoveDirection[6])
            {
                if (mathModel[lastMoveY, lastMoveX + i]?.mark?.type == curPlayerMarkType)
                {
                    marksByDirection[2]++;
                    if (marksByDirection[2] >= piecesToWin - 1)
                    {
                        return true;
                    }
                }
                else
                {
                    shouldMoveDirection[6] = false;
                }
            }
            else
            {
                shouldMoveDirection[6] = false;
            }

            // top right
            if (lastMoveX + i < fieldSize.x &&  lastMoveY - i >= 0 && shouldMoveDirection[7])
            {
                if (mathModel[lastMoveY - i, lastMoveX + i]?.mark?.type == curPlayerMarkType)
                {
                    marksByDirection[3]++;
                    if (marksByDirection[3] >= piecesToWin - 1)
                    {
                        return true;
                    }
                }
                else
                {
                    shouldMoveDirection[7] = false;
                }
            }
            else
            {
                shouldMoveDirection[7] = false;
            }


            i++;
        }

        return false;
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
        return new Mark();
        //return markPool.NewObject(players[playerNum].markType, GameObject.Find("Field").transform);
    }

    void DeleteMark(Mark mark)
    {
        markPool.DeleteObject(mark);
    }

    #endregion
}
