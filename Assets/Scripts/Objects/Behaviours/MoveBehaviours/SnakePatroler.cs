using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnakePatroler : MoveBehaviour
{
    public int verticalDirection;
    public int direction;
    public float speed;

    private Vector3 nextTurnY;

    public override void Start()
    {
        
    }

    public override void Update()
    {
        //var e = GetComponent<Enemy>();

        //if (e.moveState == MoveState.Stop)
        //{
        //    return;
        //}

        //transform.Translate(Time.deltaTime * speed * Mathf.Cos(Mathf.Deg2Rad * angle), Time.deltaTime * speed * Mathf.Sin(Mathf.Deg2Rad * angle), 0);

        ////Bounds thisBounds = GetComponent<SpriteRenderer>().bounds;
        //Bounds fieldBounds = TicTacToeGlobal.fieldBounds;
        //if (transform.position.x < fieldBounds.center.x - fieldBounds.extents.x + TicTacToeGlobal.cellSize.x / 2)
        //{
        //    if (moveUp)
        //    {
        //        angle = 90;
        //    }
        //    else
        //    {
        //        angle = -90;
        //    }
        //}
    }
}
