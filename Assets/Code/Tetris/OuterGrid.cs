using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OuterGrid
{
    public static int width = 30; //Multiply by 2 (it is 60, but 30 in each direction)
    public static int height = 30;

    public static float tileScale = 0.4f;

    public static Vector3 TranslateToGridCoordinates(Position pos)
    {
        return new Vector3(pos.x * tileScale, pos.y * tileScale, 0);
    }
}
