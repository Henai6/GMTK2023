using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    protected Tile[] form;
    public gameDirection dir { get; protected set; }
    public int tileCount { protected set; get; }

    public virtual void Initialize(Tile[] tiles, Position startPos)
    {
        //This should be abstract, but virtual will do.
        throw new NotImplementedException();
    }

    /// <summary>
    /// Resolve the tick
    /// </summary>
    /// <returns>Returns true if block is touching the end</returns>
    public virtual bool ResolveTick()
    {
        //Should have:
        //Fall
        //Check for stop
        Fall();
        //throw new NotImplementedException();
        return false;
    }

    public virtual void Fall()
    {
        //Check for out of bounds
        //Check for hit bucket
        switch (dir)
        {
            //Game direction here refers to which direction the piece are spawned from
            case gameDirection.Left:
                for (int i = 0; i < form.Length; i++)
                {
                    form[i].AddX(1);
                }
                break;
            case gameDirection.Up:
                for (int i = 0; i < form.Length; i++)
                {
                    form[i].AddY(-1);
                }
                break;
            case gameDirection.Right:
                for (int i = 0; i < form.Length; i++)
                {
                    form[i].AddX(-1);
                }
                break;
            case gameDirection.Down:
                for (int i = 0; i < form.Length; i++)
                {
                    form[i].AddY(1);
                }
                break;
            default: throw new NotImplementedException();
        }
    }

    public static Piece GetRandomPiece()
    {
        //Select random piece (currently hardcoded)
        Piece piece = new pSquare();

        //Get direction
        System.Array dirValues = System.Enum.GetValues(typeof(gameDirection));
        piece.dir = (gameDirection)dirValues.GetValue(UnityEngine.Random.Range(0, dirValues.Length));

        return piece;
    }
}
