using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType
{
    public string name;
    public Vector2Int size;
    public Vector2Int center;
    public int[,] physicalShape;
    public MoveBehaviour moveBehaviour;
    public ActionBehaviour actionBehaviour;
    public string model;
}
