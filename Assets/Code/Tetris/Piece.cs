using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

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
        bool retValue = Fall();

        if (BoundryCheck()) {
            DestroyAndLostHealth();
            return true;
        }

        return retValue;
    }

    public virtual bool Fall()
    {
        Move(dir);

        if (Bucket.player.materialized == true) { 
            //Hit an existing tile in bucket
            if (Bucket.player.GetGrid() != null && Bucket.player.GetGrid().Any(p => form.Any(t => t.position == p)))
            {
                Move(gDir.Opposite(dir));
                Bucket.player.AttachPiece(form);
                return true;
            } 
            //Hit the botttom line
            else if (form.Any(t => Bucket.player.HitBottomLine(t.position, dir)))
            {
                Move(gDir.Opposite(dir));
                Bucket.player.AttachPiece(form);
                return true;
            }
        }
        return false;
    }

    private void Move(gameDirection gDir)
    {
        switch (gDir)
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

    private bool BoundryCheck()
    {
        foreach(Tile t in form)
        {
            switch (dir)
            {
                case gameDirection.Left:
                    if (t.position.x > OuterGrid.width) return true;
                    break; 
                /*case gameDirection.Up:
                    if (t.position.y > OuterGrid.height) return true;
                    break; */
                case gameDirection.Right:
                    if (t.position.x < -OuterGrid.width) return true;
                    break; 
                case gameDirection.Down:
                    if (t.position.y < -OuterGrid.height) return true;
                    break;
                default: break;
            }
        }
        return false;
    }

    private void DestroyAndLostHealth()
    {
        //Lost Health
        ScoringManager.Instance.LostHealth();
        Debug.Log("remain hp:" + ScoringManager.Instance.GetHealth());
    }
    public static Piece GetRandomPiece()
    {
        int i = (int)UnityEngine.Random.Range(0, 7);
        Piece piece;
        switch (i)
        {
            case 0:
                piece = new pIpiece();
                break;
            case 1:
                piece = new pJpiece();
                break;
            case 2:
                piece = new pLpiece();
                break;
            case 3:
                piece = new pSpiece();
                break;
            case 4:
                piece = new pZpiece();
                break;
            case 5:
                piece = new pTpiece();
                break;
            default:
                piece = new pSquare();
                break;
        }
        
        //Get direction
        System.Array dirValues = System.Enum.GetValues(typeof(gameDirection));
        piece.dir = (gameDirection)dirValues.GetValue(UnityEngine.Random.Range(0, dirValues.Length));

        return piece;
    }
}
