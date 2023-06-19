using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TokenIdxNotification(int xIdx, int yIdx, int zIdx);

public class GameController : MonoBehaviour
{
    public int BOARD_X = 7;
    public int BOARD_Y = 7;
    public int BOARD_Z = 6;
    public event TokenIdxNotification TokenAdded;
    private int[,,] state; // TODO: should be changed to an array of player pointers

    public int GetPlayerAtIndex(int x, int y, int z)
    {
        return (int) state.GetValue(z, y, x);
    }

    public void HandleBoardClick(int xIdx, int yIdx)
    {
        // get smallest value of z that that has no token in state
        int smallestZ = 0;
        while (smallestZ < BOARD_Z && (int) state.GetValue(smallestZ, yIdx, xIdx) != 0) smallestZ++;

        if (smallestZ == BOARD_Z) return; // the entire column is filled

        state.SetValue(1, smallestZ, yIdx, xIdx);
        TokenAdded?.Invoke(xIdx, yIdx, smallestZ);
    }

    // Start is called before the first frame update
    void Awake()
    {
        state = new int[BOARD_Z, BOARD_Y, BOARD_X];
        Physics.queriesHitTriggers = true;

        for (int x = 0; x < BOARD_X; x++)
        {
            for (int y = 0; y < BOARD_Y; y++)
            {
                state.SetValue(1, 0, y, x);
            }
        }
        
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
