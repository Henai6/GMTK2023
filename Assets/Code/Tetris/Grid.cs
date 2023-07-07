using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameDirection { Left, Up, Right }

public class Grid
{
    //singleton
    private static Grid instance;
    public static Grid Instance => instance ?? (instance = new Grid());

    public bool[,] middleGrid = new bool[10, 20];
    public bool[,] leftGrid = new bool[10, 10];
    public bool[,] rightGrid = new bool[10, 10];

    public gameDirection direction = gameDirection.Up;

    //On creation
    public Grid() { }
}
