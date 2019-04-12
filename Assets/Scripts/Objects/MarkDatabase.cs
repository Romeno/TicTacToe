using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Mark Database", menuName = "Tic Tac Toe/Create Mark Database", order = 1)]
public class MarkDatabase : ScriptableObject
{
    // array where Mark.id is a key
    public MarkType[] markTypes;
}
