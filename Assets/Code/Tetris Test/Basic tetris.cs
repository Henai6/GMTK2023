using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// # Bucket tetris, and my understanding
//With the bucket type game, which surfaces can the pieces stop at?
//Also there should be visual and auditory feedback when sticking blocks
//How does on lose? block falls out of range, if so the game map should have a limited size
//There should be a button to increase tick speed, because given that a piece spawns from the top of the map,
//u and the user isn't able to exit the game area with the bucket, they would have to wait for the piece to fall.
//There should be logic to prevent new pieces from spawning where the bucket is. 
//Make button to materialize the playing field? So as to also have a losing condition for when blocks
//are stuck to the outside of the bucket, but also make the bucket more usable.

//Need a method to translate grid position to visual position

//---------------------------------------



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
