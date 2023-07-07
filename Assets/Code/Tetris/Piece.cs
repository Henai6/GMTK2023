using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    protected Vector2[] position;

    /// <summary>
    /// Resolve the tick
    /// </summary>
    /// <returns>Returns true if block is touching the end</returns>
    public virtual bool ResolveTick()
    {
        //Should have:
        //Rotate
        //Fall
        //Check for stop
        Fall();
        throw new NotImplementedException();
    }

    public virtual void Fall()
    {
        switch (Grid.Instance.direction)
        {
            case gameDirection.Left:
                for (int i = 0; i < position.Length; i++)
                {
                    position[i].x += 1;
                }
                break;
            case gameDirection.Up:
                for (int i = 0; i < position.Length; i++)
                {
                    position[i].y -= 1;
                }
                break;
            case gameDirection.Right:
                for (int i = 0; i < position.Length; i++)
                {
                    position[i].x -= 1;
                }
                break;
            default: throw new NotImplementedException();
        }
    }
}
