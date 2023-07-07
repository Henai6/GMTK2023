using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//What does tetris need
//A list of shapes
//Something that creates blocks
//Blocks should continue falling till they have reached an end point
//When reaching their endpoint a clearRows() method should be called
//Also, after a row is cleared, all cells should be checked for falling blocks.
//Which direction are cells cleared from???


//Make tetris field 

public class Basictetris : MonoBehaviour
{
    private int width = 10;
    private int height = 20;
    private bool[,] grid;

    //From where does the next piece spawn?
    private int xSelection;

    private float TickSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        xSelection = width / 10;
        grid = new bool[width, height];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When spawning new piece, what should its position be
    void SetNewPiecePostion()
    {
        if (xSelection == width)
        {
            xSelection = width - 1;
        }
        //Spawn bottom leftmost tile of piece at xSelection, height
    }
}
