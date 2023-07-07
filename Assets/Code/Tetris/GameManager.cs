using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//This should maybe be the only MonoBehaviour object
public class GameManager : MonoBehaviour
{
    private float TickSpeed = 0.5f;
    private float curTime = 0f;
    private Piece curPiece; //Set at some point
    
    
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > TickSpeed)
        {
            curTime -= TickSpeed;
            OnTick();
        }
        //PlayerInput() //Check for player input and handle it 
    }

    private void OnTick()
    {
        if (curPiece.ResolveTick())
        {
            //Change piece
        }
    }
}
