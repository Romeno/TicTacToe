using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TicTacToeGlobal
{
    public static TicTacToeViews _views;
    public static ModalManager _modalManager;
    public static MusicManager _musicManager;

    public static List<EnemyType> enemyTypes;
    public static List<ObstacleType> obstacleTypes;
    public static List<Map> maps;

    public static TicTacToeViews views
    {
        get
        {
            return GameObject.Find("Game Views").GetComponent<TicTacToeViews>();
        }
    }

    public static ModalManager modalManager
    {
        get
        {
            return GameObject.Find("Modal Manager").GetComponent<ModalManager>();
        }
    }

    public static MusicManager musicManager
    {
        get
        {
            return GameObject.Find("Music Manager").GetComponent<MusicManager>();
        }
    }


    public static Vector2Int fieldSizeInCells
    {
        get
        {
            return GameObject.Find("TicTacToe").GetComponent<TicTacToePlayArea>().playAreaSize;
        }
    }

    public static Bounds fieldBounds
    {
        get
        {
            var ttt = GameObject.Find("TicTacToe").GetComponent<TicTacToe>();
            var tttpa = GameObject.Find("TicTacToe").GetComponent<TicTacToePlayArea>();

            Bounds cellBounds = ttt.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds;
            Vector3 size = new Vector3(
                fieldSizeInCells.x * cellBounds.size.x + (fieldSizeInCells.x - 1) * tttpa.spacing,
                fieldSizeInCells.y * cellBounds.size.y + (fieldSizeInCells.y - 1) * tttpa.spacing,
                0);

            return new Bounds(ttt.background.transform.position, size);
        }
    }

    public static Vector3 cellSize
    {
        get
        {
            var ttt = GameObject.Find("TicTacToe").GetComponent<TicTacToe>();

            Bounds cellBounds = ttt.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds;
            return new Vector3(cellBounds.size.x, cellBounds.size.y, 0);
        }
    }

    public static float cellSpacing
    {
        get
        {
            var tttpa = GameObject.Find("TicTacToe").GetComponent<TicTacToePlayArea>();

            return tttpa.spacing;
        }
    }

    public static Cell GetCell(int x, int y)
    {
        var ttt = GameObject.Find("TicTacToe").GetComponent<TicTacToe>();

        return ttt.mathModel[y, x];
    }

    public static Cell GetCell(Vector3 pos)
    {
        var ttt = GameObject.Find("TicTacToe").GetComponent<TicTacToe>();
        var center = ttt.background.transform.position;
        int cellX = -1, cellY = -1;

        float offX = pos.x - (fieldBounds.center.x - fieldBounds.extents.x) - cellSize.x;
        if (offX % (cellSpacing + cellSize.x) > cellSpacing)
        {
            cellX = (int)(offX / (cellSpacing + cellSize.x));
        }
        else
        {
            return null;
        }

        float offY = (fieldBounds.center.y + fieldBounds.extents.y) - pos.y - cellSize.y;
        if (offY % (cellSpacing + cellSize.y) > cellSpacing)
        {
            cellY = (int)(offY / (cellSpacing + cellSize.y));
        }
        else
        {
            return null;
        }

        return ttt.mathModel[cellY + 1, cellX + 1];
    }

    public static void RemoveMark(int x, int y)
    {
        var ttt = GameObject.Find("TicTacToe").GetComponent<TicTacToe>();

        ttt.RemoveMark(x, y);
    }

    public static void RemoveMark(Vector3 pos)
    {
        var ttt = GameObject.Find("TicTacToe").GetComponent<TicTacToe>();

        Cell c = GetCell(pos);

        ttt.RemoveMark(c);
    }
}
