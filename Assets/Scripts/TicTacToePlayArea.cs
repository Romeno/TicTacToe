using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToePlayArea : MonoBehaviour
{
    public Vector2Int playAreaSize;
    public float spacing;
    public SpriteRenderer bgObj;
    public Cell cellPrefab;


    private void Reset()
    {
        playAreaSize = new Vector2Int(3, 3);
        spacing = 0.2f;
    }
}
