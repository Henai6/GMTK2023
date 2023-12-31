using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

//This should maybe be the only MonoBehaviour object
public class GameManager : MonoBehaviour
{
    private static string[] _path = {"Red", "Green", "Blue", "Yellow", "Purple", "Cyan", "Orange"};

    public static GameManager instance;
    private float tickSpeed = 0.5f;
    private float curTime = 0f;
    private List<Piece> curPieces = new List<Piece>();
    public GameObject tilePrefab;
    private void Start()
    {
        AddPiece();
        instance = this;
    }

    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > tickSpeed)
        {
            EventDispatcher.Instance.IndexedEvent(3);
            curTime = 0f;
            OnTick();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddPiece();
        }
    }

    private void OnTick()
    {
        foreach(Piece piece in curPieces.ToList())
        {
            if (piece != null) { 
                if (piece.ResolveTick())
                {
                    curPieces.Remove(piece); //removes reference to old piece
                    AddPiece();
                }
            }
        }
    }

    public void AddPiece()
    {
        //Get piece
        Piece newPiece = Piece.GetRandomPiece();

        //Get spawn position
        Position spawnPos;
        int spawnAxis = Random.Range(-OuterGrid.width + 2, OuterGrid.width - 2); //Assuming width and height is equal
        switch (newPiece.dir)
        {
            //These positions are temporary, should be more random and width and height should come from grid
            case gameDirection.Left:
                spawnPos = new Position(-OuterGrid.width, spawnAxis); 
                break;
            case gameDirection.Right:
                spawnPos = new Position(OuterGrid.width, spawnAxis);
                break; 
            case gameDirection.Up:
                spawnPos = new Position(spawnAxis, OuterGrid.height);
                break;
            case gameDirection.Down:
                spawnPos = new Position(spawnAxis, -OuterGrid.height);
                break;
            default:
                throw new System.NotImplementedException();
        }

        //Spawn tiles
        Tile[] tiles= new Tile[newPiece.tileCount];
        for (int i = 0; i < newPiece.tileCount; i++)
        {
            tiles[i] = Instantiate(tilePrefab, OuterGrid.TranslateToGridCoordinates(spawnPos), Quaternion.identity).GetComponent<Tile>();
            tiles[i].Initialize(spawnPos);
        }

        int color = (int)UnityEngine.Random.Range(0, 7);

        Sprite ranSprite = Resources.Load<Sprite>(_path[color]);
        foreach (Tile t in tiles)
        {
            SpriteRenderer sr = t.gameObject.GetComponent<SpriteRenderer>();
            sr.sprite = ranSprite;
        }

        //The tiles are clumbed up at the spawn position, shape them in 'Initialize()'
        newPiece.Initialize(tiles, spawnPos);

        curPieces.Add(newPiece);
    }
}
