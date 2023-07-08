using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameDirection { Up, Left, Right, Down } 

public class Bucket : MonoBehaviour
{
    public static Bucket player;

    private gameDirection dir = gameDirection.Up;
    private Position pivot = new Position(0, 0);

    public Tile[,] grid = new Tile[10, 20];

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
        curTime += Time.deltaTime;
        if (curTime > tickSpeed)
        {
            curTime = 0f;
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector3 bucketPos = this.transform.position;
            if (horizontalInput != 0)
            {
                bucketPos.x += OuterGrid.tileScale * horizontalInput;
            }
            if (verticalInput != 0)
            {
                bucketPos.y += OuterGrid.tileScale * verticalInput;
            }
            this.transform.position = bucketPos;
        }
    }
}
