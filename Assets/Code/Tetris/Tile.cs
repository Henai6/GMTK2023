using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;


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


public struct Position : IEquatable<Position>
{
    public Position(int X, int Y)
    {
        x = X;
        y = Y;
    }

    public int x;
    public int y;

    public override string ToString() => $"({x}, {y})";

    public override bool Equals(object o)
    {
        if (o == null)
            return false;
        return Equals((Position)o);
    }


    public bool Equals(Position other)
    {
        return (x == other.x && y == other.y);
    }

    public static bool operator ==(Position left, Position right) => left.Equals(right);
    public static bool operator !=(Position left, Position right) => !left.Equals(right);
}