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
        for (int z = 0; z < BOARD_Z; z++)
        {
            for (int x = 0; x < BOARD_X; x++)
            {
                for (int y = 0; y < BOARD_Y; y++)
                {
                    state.SetValue(1, z, y, x);
                }
            }
        }
        Camera.main.transform.position = new Vector3(BOARD_X * 3, BOARD_Y * 3, BOARD_Z * 3);
        Camera.main.transform.rotation = Quaternion.LookRotation(-new Vector3(BOARD_X, BOARD_Y, BOARD_Z), Vector3.forward);
        Board board = Instantiate<Board>(boardPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        board.gameController = this;
    }
}
