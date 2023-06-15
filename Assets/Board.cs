using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameController gameController;
    public Token tokenPrefab;
    private Token[,,] tokens;

    private void InstantiateBoard()
    {
        for (int x = 0; x < gameController.BOARD_X; x++)
        {
            for (int y = 0; y < gameController.BOARD_Y; y++)
            {
                for (int z = 0; z < gameController.BOARD_Z; z++)
                {
                    int player = gameController.GetPlayerAtIndex(x, y, z);
                    if (player == 0) continue;
                    
                    Token tokenClone = Instantiate<Token>(tokenPrefab, new Vector3(x, y, z), Quaternion.identity, this.transform);
                    tokens.SetValue(tokenClone, z, y, x);
                    if (player == 1) { tokenClone.color = Color.yellow; continue; }
                    tokenClone.color = Color.red; 
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tokens = new Token[gameController.BOARD_Z, gameController.BOARD_Y, gameController.BOARD_X];
        InstantiateBoard();
    }
}
