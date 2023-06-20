using System.Collections.Generic;
using UnityEngine;

public class WinDetector : MonoBehaviour
{
    public int TOKEN_WIN_COUNT = 4;
    private List<Vector3Int> directions = new List<Vector3Int>(){
        new Vector3Int(0, 0, 1),
        new Vector3Int(0, 1, 0),
        new Vector3Int(1, 0, 0),
        new Vector3Int(0, 1, 1),
        new Vector3Int(1, 0, 1),
        new Vector3Int(1, 1, 0),
        new Vector3Int(1, 1, 1),
        new Vector3Int(0, 1, -1),
        new Vector3Int(0, -1, 1),
        new Vector3Int(1, 0, -1),
        new Vector3Int(-1, 0, 1),
        new Vector3Int(1, -1, 0),
        new Vector3Int(-1, 1, 0)
    };
    private List<int[,,]> kernals = new List<int[,,]>(13);

    void Awake()
    {
        // bake the kernals based on the directions
        Vector3Int indexAddend;
        foreach (Vector3Int direction in directions)
        {
            int kernalSize = 2 * TOKEN_WIN_COUNT - 1;
            int kernalMidpoint = TOKEN_WIN_COUNT - 1;
            int[,,] kernal = new int[kernalSize, kernalSize, kernalSize];
            kernal[kernalMidpoint, kernalMidpoint, kernalMidpoint] = 1;
            for (int i = 1; i < TOKEN_WIN_COUNT; i++)
            {
                indexAddend = direction * i;
                kernal[kernalMidpoint + indexAddend.x, kernalMidpoint + indexAddend.y, kernalMidpoint + indexAddend.z] = 1;
            }
            kernals.Add(kernal);
        }
    }

    public bool IsWinner(Player[,,] state, Player player)
    {
        // i know this looks bad but it's basically O(1) for a fixed board size so it's ok
        int convolutionAccumulator;
        int[,,] kernal;
        for (int kernalIdx = 0; kernalIdx < 13; kernalIdx++)
        {
            kernal = kernals[kernalIdx];
            for (int z = 0; z < state.GetLength(0); z++)
            {
                for (int y = 0; y < state.GetLength(1); y++)
                {
                    for (int x = 0; x < state.GetLength(2); x++)
                    {
                        convolutionAccumulator = 0;
                        for (int i = 1 - TOKEN_WIN_COUNT; i <= TOKEN_WIN_COUNT - 1; i++)
                        {
                            for (int j = 1 - TOKEN_WIN_COUNT; j <= TOKEN_WIN_COUNT -1 ; j++)
                            {
                                for (int k = 1 - TOKEN_WIN_COUNT; k <= TOKEN_WIN_COUNT - 1; k++)
                                {
                                    if (z + i >= state.GetLength(0) || y + j >= state.GetLength(1) || x + k >= state.GetLength(2)) continue;
                                    if (z + i < 0 || y + j < 0 || x + k < 0) continue;

                                    if ((Player) state.GetValue(z + i, y + j, x + k) == player)
                                    {
                                        convolutionAccumulator += (int) kernal.GetValue(i + TOKEN_WIN_COUNT - 1, j + TOKEN_WIN_COUNT - 1, k + TOKEN_WIN_COUNT - 1);
                                    }
                                    if (convolutionAccumulator >= TOKEN_WIN_COUNT)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return false;
    }
}
