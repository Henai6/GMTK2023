using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameDirection { Up, Left, Right, Down } 

public class Bucket : MonoBehaviour
{
    public static Bucket player; //I have not bothered ensuring it is a singleton

    private gameDirection dir = gameDirection.Up;
    private Position pivot = new Position(0, 0);
    private Position pos = new Position(0, 0);

    public Tile[,] grid = new Tile[9, 19];

    private float tickSpeed = 0.5f;
    private float curTime = 0f;

    //When blocks fall, they should be able to get this objects position

    //Should have a rotate
    //Should have a move
    //Should have a rotate pivot
    //Should have a materialize

    void Start()
    {
        player = this;
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            pos.x += (int)Input.GetAxisRaw("Horizontal");
        }
        if (Input.GetButtonDown("Vertical"))
        {
            pos.y += (int)Input.GetAxisRaw("Vertical");
        }
        this.transform.position = OuterGrid.TranslateToGridCoordinates(pos);
    }

    public Position[] GetGrid()
    {
        List<Position> tileList = new List<Position>();

        int yDir = 1;
        int xDir = 1;
        if (dir == gameDirection.Down) { yDir = -1; }
        if (dir == gameDirection.Left) { xDir = -1; }

        for (int i = 0; i > grid.GetLength(0); i++)
        {
            for (int j = 0; j > grid.GetLength(1); j++)
            {
                if (grid[i,j] != null)
                {
                    tileList.Add(new Position(pos.x + i * xDir, pos.y + j * yDir));
                    //^^ maybe not ideal, as each tile in the bucket causes a object to be created every tick
                }
            }
        }
        return null;
    }

    public bool HitBottomLine(Position other, gameDirection otherDir)
    {
        int width = grid.GetLength(0);
        Position[] bottomLine = new Position[width];

        switch (dir, otherDir)
        {
            //Not sure if bottomLine is correct with the -1
            case (gameDirection.Up, gameDirection.Down):
                for (int i = 0; i < width; i++)
                {
                    bottomLine[i] = new Position(pos.x - (width - 1)/2 + i, pos.y - 1);
                }
                break;
            case (gameDirection.Down, gameDirection.Up):
                for (int i = 0; i < width; i++)
                {
                    bottomLine[i] = new Position(pos.x - (width - 1) / 2 + i, pos.y);
                }
                break;
            case (gameDirection.Left, gameDirection.Right):
                for (int i = 0; i < width; i++)
                {
                    bottomLine[i] = new Position(pos.x - 1, pos.y - (width - 1) / 2 + i);
                }
                break;
            case (gameDirection.Right, gameDirection.Left):
                for (int i = 0; i < width; i++)
                {
                    bottomLine[i] = new Position(pos.x, pos.y - (width - 1) / 2 + i);
                }
                break;
            default:
                return false;
        }

        return bottomLine.Any(p => p.x == other.x && p.y == other.y);
    }
}
