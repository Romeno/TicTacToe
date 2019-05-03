using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColumnPatroler : MoveBehaviour
{
    public int direction;
    public float speed;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        var e = c.GetComponent<Enemy>();

        if (e.moveState == MoveState.Stop)
        {
            return;
        }

        Bounds fieldBounds = TicTacToeGlobal.fieldBounds;
        // top
        if (direction > 0)
        {
            float newY = c.transform.position.y + speed * Time.deltaTime;
            float borderY = fieldBounds.center.y + fieldBounds.extents.y - TicTacToeGlobal.cellSize.y / 2;
            if (newY > borderY)
            {
                newY = borderY;
                direction = -direction;
            }

            c.transform.position = new Vector3(c.transform.position.x, newY, c.transform.position.z);
        }
        // bottom
        else
        {
            float newY = c.transform.position.y - speed * Time.deltaTime;
            float borderY = fieldBounds.center.y - fieldBounds.extents.y + TicTacToeGlobal.cellSize.y / 2;
            if (newY < borderY)
            {
                newY = borderY;
                direction = -direction;
            }

            c.transform.position = new Vector3(c.transform.position.x, newY, c.transform.position.z);
        }
    }
}
