using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public string name;
    public Vector2Int size;
    public float spacing;
    public int minPlayers;
    public int maxPlayers;
    public int piecesToWin;

    public Obstacle[] obstacles;
    public Enemy[] enemies;
}
