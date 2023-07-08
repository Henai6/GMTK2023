using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pZpiece : Piece
{
    public pZpiece()
    {
        tileCount = 4;
    }

    public override void Initialize(Tile[] tiles, Position startPos)
    {
        form = tiles;

        //These should change depening on the direction of the piece.
        tiles[1].AddX(1);
        tiles[2].AddY(1);
        tiles[3].AddX(-1); tiles[3].AddY(1);
    }
}