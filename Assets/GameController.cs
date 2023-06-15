using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int BOARD_X = 7;
    public int BOARD_Y = 7;
    public int BOARD_Z = 6;
    private int[,,] state; // TODO: should be changed to an array of player pointers
    public Board boardPrefab;

    public int GetPlayerAtIndex(int x, int y, int z)
    {
        return (int) state.GetValue(z, y, x);
    }

    // Start is called before the first frame update
    void Start()
    {
        state = new int[BOARD_Z, BOARD_Y, BOARD_X];
        state.SetValue(2, 0, 0, 0);
        state.SetValue(1, 0, 0, 1);
        Board board = Instantiate<Board>(boardPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        board.gameController = this;
    }
}
