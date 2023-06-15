using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int BOARD_X = 7;
    public int BOARD_Y = 7;
    public int BOARD_Z = 6;
    public int[,,] state { get; private set; } // TODO: should be changed to an array of player pointers
    public Board board;

    public int GetPlayerAtIndex(int x, int y, int z)
    {
        if (x < 0 || x >= BOARD_X)
        {
            throw new IndexOutOfRangeException($"x: {x}");
        }
        
        if (y < 0 || y >= BOARD_Y)
        {
            throw new IndexOutOfRangeException($"y: {y}");
        }
        
        if (z < 0 || z >= BOARD_Z)
        {
            throw new IndexOutOfRangeException($"z: {z}");
        }

        return state[z, y, x];
    }

    // Start is called before the first frame update
    void Start()
    {
        state = new int[BOARD_Z, BOARD_Y, BOARD_X];
        state.SetValue(1, 0, 0, 0);
        board = Instantiate<Board>(board, new Vector3(0f, 0f, 0f), Quaternion.identity);
        board.gameController = this;
    }
}
