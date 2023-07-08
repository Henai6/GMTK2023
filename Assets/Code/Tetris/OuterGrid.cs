using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OuterGrid
{
    public static int width = 40; //temp values
    public static int height = 40;

    public static float tileScale = 0.4f;

    public static Vector3 TranslateToGridCoordinates(Position pos)
    {
        return new Vector3(pos.x * tileScale, pos.y * tileScale, 0);
    }
}
