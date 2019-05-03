using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MarkPreventerRadial : MonoBehaviour
{
    public int direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var e = GetComponent<Enemy>();
        var a = GetComponent<Animator>();
        Cell c = TicTacToeGlobal.GetCell(transform.position);

        if (e.actionState == ActionState.Attack && a.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !a.IsInTransition(0))
        {
            e.moveState = MoveState.Move;
            e.actionState = ActionState.Idle;
            TicTacToeGlobal.RemoveMark(transform.position);
        }

        if (c.mark != null)
        {
            if (e.actionState != ActionState.Attack)
            {
                e.moveState = MoveState.Stop;
                e.actionState = ActionState.Attack;
                a.SetTrigger("Attack");
            }
        }
    }
}
