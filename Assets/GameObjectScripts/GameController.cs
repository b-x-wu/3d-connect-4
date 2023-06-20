using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TokenIdxNotification(int xIdx, int yIdx, int zIdx, Player player);
public delegate void WinnerNotification(Player player);

public class GameController : MonoBehaviour
{
    public int BOARD_X = 7;
    public int BOARD_Y = 7;
    public int BOARD_Z = 6;
    public int PLAYER_COUNT = 2;
    public event TokenIdxNotification TokenAdded;
    public event WinnerNotification PlayerWon;
    private Player[] players;
    private Player[,,] state;
    private int currentPlayerIdx;
    private WinDetector winDetector;

    public Player GetPlayerAtIndex(int x, int y, int z)
    {
        return (Player) state.GetValue(z, y, x);
    }

    public void HandleBoardClick(int xIdx, int yIdx)
    {
        // get smallest value of z that that has no token in state
        int smallestZ = 0;
        while (smallestZ < BOARD_Z && (Player) state.GetValue(smallestZ, yIdx, xIdx) != null) smallestZ++;

        if (smallestZ == BOARD_Z) return; // the entire column is filled

        state.SetValue(players[currentPlayerIdx], smallestZ, yIdx, xIdx);
        TokenAdded?.Invoke(xIdx, yIdx, smallestZ, players[currentPlayerIdx]);
        if (winDetector.IsWinner(state, players[currentPlayerIdx]))
        {
            Debug.Log($"Player {players[currentPlayerIdx].id} wins.");
            PlayerWon?.Invoke(players[currentPlayerIdx]);
            return;
        }

        currentPlayerIdx = (currentPlayerIdx + 1) % PLAYER_COUNT;
    }

    void Awake()
    {
        state = new Player[BOARD_Z, BOARD_Y, BOARD_X];
        players = new Player[PLAYER_COUNT];
        for (int idx = 0; idx < PLAYER_COUNT; idx++) players[idx] = new Player(idx + 1, UnityEngine.Random.ColorHSV());
        currentPlayerIdx = 0;
        winDetector = GetComponent<WinDetector>();
        Physics.queriesHitTriggers = true;
    }
}
