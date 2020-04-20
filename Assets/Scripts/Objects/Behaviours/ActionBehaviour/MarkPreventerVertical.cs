using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MarkPreventerVertical : MonoBehaviour
{
    // in cells
    public int distance;

    void Start()
    {

    }

    void Update()
    {
        var e = GetComponent<Enemy>();
        var a = GetComponent<Animator>();
        Cell c = TicTacToeGlobal.GetCell(transform.position);

        if (e.data.actionState == ActionState.Attack && a.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !a.IsInTransition(0))
        {
            e.data.moveState = MoveState.Move;
            e.data.actionState = ActionState.Idle;
            TicTacToeGlobal.RemoveMark(transform.position);
        }

        if (c.mark != null)
        {
            if (e.data.actionState != ActionState.Attack)
            {
                e.data.moveState = MoveState.Stop;
                e.data.actionState = ActionState.Attack;
                a.SetTrigger("Attack");
            }
        }
    }
}
