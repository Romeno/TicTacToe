using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mark Type", menuName = "Tic Tac Toe/Create Mark Type", order = 1)]
public class MarkType : ScriptableObject, IRObjectType
{
    [SerializeField]
    private GameObject _prefab;

    public int id;
    public GameObject objectPrefab
    {
        get
        {
            return _prefab;
        }
        set
        {
            _prefab = value;
        }
    }
}
