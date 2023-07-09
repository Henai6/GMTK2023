using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum gameDirection { Up, Right, Down, Left } 


public class Bucket : MonoBehaviour
{
    public static Bucket player; //I have not bothered ensuring it is a singleton

    private gameDirection dir = gameDirection.Up;
    private Position pivot = new Position(1, 0); //Looks better when 1 is added to x
    private Position pos = new Position(0, 0);
    public bool materialized = false;
    private float opacity;
    private SpriteRenderer[] bucketSprites;

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
        bucketSprites = this.GetComponentsInChildren<SpriteRenderer>();
        opacity = bucketSprites[0].color.a;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!materialized)
            {
                ChangeOppacity(false);
            }
        }
        else
        {
            if (materialized) {
                ChangeOppacity(true);
            }

            //Movement
            if (Input.GetButtonDown("Horizontal"))
            {
                pos.x += (int)Input.GetAxisRaw("Horizontal");
            }
            if (Input.GetButtonDown("Vertical"))
            {
                pos.y += (int)Input.GetAxisRaw("Vertical");
            }
            this.transform.position = OuterGrid.TranslateToGridCoordinates(pos);

            Rotate();
        }
    }

    private void ChangeOppacity(bool transparent)
    {
        materialized = !transparent;
        if (transparent)
        {
            foreach (SpriteRenderer sp in bucketSprites)
            {
                Color temp = sp.color;
                temp.a = opacity;
                sp.color = temp;
            }
        }
        else
        {
            foreach (SpriteRenderer sp in bucketSprites)
            {
                Color temp = sp.color;
                temp.a = 1f;
                sp.color = temp;
            }
        }
    }

    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.transform.RotateAround(OuterGrid.TranslateToGridCoordinates(pos + pivot), Vector3.back, 90f);

            int intermediate = ((int)dir + 1) % gDir.dirCount;
            dir = (gameDirection)intermediate;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.RotateAround(OuterGrid.TranslateToGridCoordinates(pos + pivot), Vector3.back, -90f);
            if (dir - 1 < 0 )
            {
                dir = (gameDirection) gDir.dirCount - 1;
            } 
            else
            {
                dir = dir - 1;
            }
        }
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
            case (gameDirection.Up, gameDirection.Up):
                for (int i = 0; i < width; i++)
                {
                    bottomLine[i] = new Position(pos.x - (width - 1)/2 + i, pos.y);
                }
                break;
            case (gameDirection.Down, gameDirection.Down):
                for (int i = 0; i < width; i++)
                {
                    bottomLine[i] = new Position(pos.x - (width - 1) / 2 + i, pos.y);
                }
                break;
            case (gameDirection.Left, gameDirection.Left):
                for (int i = 0; i < width; i++)
                {
                    bottomLine[i] = new Position(pos.x, pos.y - (width - 1) / 2 + i);
                }
                break;
            case (gameDirection.Right, gameDirection.Right):
                for (int i = 0; i < width; i++)
                {
                    bottomLine[i] = new Position(pos.x, pos.y - (width - 1) / 2 + i);
                }
                break;
            default:
                return false;
        }

        return bottomLine.Any(p => p == other);
    }

    public void AttachPiece(Tile[] newTiles)
    {
        foreach (Tile tile in newTiles)
        {   
            tile.transform.SetParent(this.transform);
            Position relativeGrid = this.pos - tile.position;
            
            int paddleWidth = (grid.GetLength(0) - 1) / 2;
            switch (dir)
            {
                //This was awful to debug
                case gameDirection.Left:
                    int tempL = relativeGrid.x;
                    relativeGrid.x = Math.Abs(relativeGrid.y - paddleWidth);
                    relativeGrid.y = tempL - 1;
                    break;
                case gameDirection.Up:
                    relativeGrid.y *= -1;
                    int tempY = relativeGrid.y;
                    relativeGrid.x = Math.Abs(relativeGrid.x - paddleWidth);
                    relativeGrid.y = tempY - 1;
                    break; 
                case gameDirection.Right:
                    int tempX = relativeGrid.y;
                    relativeGrid.y = relativeGrid.x * (-1) - 1;
                    relativeGrid.x = tempX + paddleWidth;
                    break;
                case gameDirection.Down:
                    int tempY2 = relativeGrid.y;
                    relativeGrid.x += paddleWidth;
                    relativeGrid.y = tempY2 - 1;
                    break;
            }
            grid[relativeGrid.x, relativeGrid.y] = tile;
        }
        GameManager.instance.AddPiece();
    }
}
public class gDir
{
    public static int dirCount = System.Enum.GetValues(typeof(gameDirection)).Length;
    public static gameDirection Opposite(gameDirection inp)
    {
        switch (inp)
        {
            case gameDirection.Up: return gameDirection.Down;
            case gameDirection.Left: return gameDirection.Right;
            case gameDirection.Right: return gameDirection.Left;
            case gameDirection.Down: return gameDirection.Up;
            default: throw new Exception();
        }
    }
}