using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//This should maybe be the only MonoBehaviour object
public class GameManager : MonoBehaviour
{
    private float tickSpeed = 0.5f;
    private float curTime = 0f;
    private Piece curPiece; //Set at some point
    public GameObject tilePrefab;

    private void Start()
    {
        SetPiece();
    }

    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > tickSpeed)
        {
            curTime = 0f;
            OnTick();
        }
    }

    private void OnTick()
    {
        if (curPiece.ResolveTick())
        {
            SetPiece();
        }
    }

    private void SetPiece()
    {
        //Get piece
        curPiece = Piece.GetRandomPiece();

        //Get spawn position
        Position spawnPos;
        switch (curPiece.dir)
        {
            //These positions are temporary, should be more random and width and height should come from grid
            case gameDirection.Left:
                spawnPos = new Position(-10, 0); 
                break;
            case gameDirection.Right:
                spawnPos = new Position(10, 0);
                break; 
            case gameDirection.Up:
                spawnPos = new Position(0, 10);
                break;
            case gameDirection.Down:
                spawnPos = new Position(0, -10);
                break;
            default:
                throw new System.NotImplementedException();
        }

        //Spawn tiles
        Tile[] tiles= new Tile[curPiece.tileCount];
        for (int i = 0; i < curPiece.tileCount; i++)
        {
            tiles[i] = Instantiate(tilePrefab, OuterGrid.TranslateToGridCoordinates(spawnPos), Quaternion.identity).GetComponent<Tile>();
            tiles[i].Initialize(spawnPos);
        }

        //The tiles are clumbed up at the spawn position, shape them in 'Initialize()'
        curPiece.Initialize(tiles, spawnPos); 
    }
}
