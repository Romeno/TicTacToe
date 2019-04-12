using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToePlayArea : MonoBehaviour
{
    public Vector2Int playableAreaSize;
    public float spacing;
    public GameObject backgroundPrefab;
    public Cell cellPrefab;

    private void Reset()
    {
        playableAreaSize = new Vector2Int(3, 3);
        spacing = 0.2f;
    }
}
