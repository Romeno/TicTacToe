using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Player(MarkType markType, bool ai, string name)
    {
        this.markType = markType;
        this.ai = ai;
        this.name = name;
    }

    public MarkType markType;
    public bool ai;
    public string name;
}
