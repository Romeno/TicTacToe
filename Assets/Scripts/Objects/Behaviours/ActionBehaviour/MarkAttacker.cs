using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public abstract class MarkAttacker : ActionBehaviour
{
    protected List<Cell> affectedCells;

    public override void Start()
    {

    }

    public override void Update()
    {

        var e = c.GetComponent<Enemy>();
        var a = c.GetComponent<Animator>();

        if (e.actionState == ActionState.Attack)
        {
            if (a.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !a.IsInTransition(0))
            {
                GetAffectedCells();

                foreach (Cell c in affectedCells)
                {
                    e.moveState = MoveState.Move;
                    e.actionState = ActionState.Idle;
                    TicTacToeGlobal.RemoveMark(c.transform.position);
                }
            }
        }
        else
        {
            GetAffectedCells();

            if (affectedCells.FirstOrDefault(c => c.mark != null) != null)
            {
                e.moveState = MoveState.Stop;
                e.actionState = ActionState.Attack;
                a.SetTrigger("Attack");
            }
        }
    }

    public abstract void GetAffectedCells();
}
