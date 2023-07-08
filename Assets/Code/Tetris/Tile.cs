using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This will be MonoBehaviour, so as to allow visual movement
public class Tile : MonoBehaviour
{
    public Position position;

    public void AddX(int x)
    {
        position.x += x;
        this.transform.position = OuterGrid.TranslateToGridCoordinates(position);
    }
    public void AddY(int y)
    {
        position.y += y;
        this.transform.position = OuterGrid.TranslateToGridCoordinates(position);
    }

    public void Initialize(Position pos)
    {
        position = pos;
    }
}


public struct Position
{
    public Position(int X, int Y)
    {
        x = X;
        y = Y;
    }

    public int x;
    public int y;

    public override string ToString() => $"({x}, {y})";
}