using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameDirection { Left, Up, Right, Down } 

public class Grid //Rename to bucket and create a new grid class for an outer grid or world grid.
{
    //singleton
    private static Grid instance;
    public static Grid Instance => instance ?? (instance = new Grid());

    public Tile[,] middleGrid = new Tile[10, 20];

    //public gameDirection direction = gameDirection.Up;

    //On creation
    public Grid() { }
}
