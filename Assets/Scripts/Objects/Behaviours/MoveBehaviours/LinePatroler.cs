using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LinePatroler: MoveBehaviour
{
    public int direction;
    public float speed;

    public override void Start()
    {
        
    }

    public override void Update()
    {
        var e = c.GetComponent<Enemy>();

        if (e.data.moveState == MoveState.Stop)
        {
            return;
        }

        Bounds fieldBounds = TicTacToeGlobal.fieldBounds;
        // right
        if (direction > 0)
        {
            float newX = c.transform.position.x + speed * Time.deltaTime;
            float borderX = fieldBounds.center.x + fieldBounds.extents.x - TicTacToeGlobal.cellSize.x / 2;
            if (newX > borderX)
            {
                newX = borderX;
                direction = -direction;
            }

            c.transform.position = new Vector3(newX, c.transform.position.y, c.transform.position.z);
        }
        // left
        else
        {
            float newX = c.transform.position.x - speed * Time.deltaTime;
            float borderX = fieldBounds.center.x - fieldBounds.extents.x + TicTacToeGlobal.cellSize.x / 2;
            if (newX < borderX)
            {
                newX = borderX;
                direction = -direction;
            }

            c.transform.position = new Vector3(newX, c.transform.position.y, c.transform.position.z);
        }
    }
}
