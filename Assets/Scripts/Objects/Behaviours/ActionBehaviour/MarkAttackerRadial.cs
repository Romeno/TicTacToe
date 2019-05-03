using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MarkAttackerRadial : MarkAttacker
{
    // in cells
    public int radius;

    public override void GetAffectedCells()
    {
        affectedCells.Clear();

        // now does not account for radius
        Cell cell = TicTacToeGlobal.GetCell(c.transform.position);
    }
}
