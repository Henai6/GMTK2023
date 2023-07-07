using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTest : MonoBehaviour
{
    private Vector2[] position = {
        new Vector2(0, 0),
        new Vector2(0, 1),
        new Vector2(1, 0),
        new Vector2(1, 1)
        };

    void UpdatePosition()
    {
        //Before moving, check grid if there is anything at the new location
        for (int i = 0; i < position.Length; i++)
        {
            position[i].y -= 1;
        }
    }
}