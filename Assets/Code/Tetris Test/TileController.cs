using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TileController : MonoBehaviour
{
    private Vector2[] currentTile = {
        new Vector2(0, 0),
        new Vector2(0, 1),
        new Vector2(1, 0),
        new Vector2(1, 1)
        };

    // Start is called before the first frame update
    void Start()
    {
        //Set tile here
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInput();
    }

    private void CheckPlayerInput()
    {
        float input = Input.GetAxisRaw("Horizontal");
        if (input != 0)
        {
            for (int i = 0; i < currentTile.Length; i++)
            {
                currentTile[i].x += input;
            }
        }
    }
}
