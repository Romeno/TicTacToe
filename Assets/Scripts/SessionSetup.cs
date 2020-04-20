using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionSetup : MonoBehaviour
{
    public Vector2Int playAreaSize;

    public int piecesToWin;

    public List<Player> players;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameState");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        players = new List<Player>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
