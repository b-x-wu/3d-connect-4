using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameController gameController;
    public Token tokenPrefab;
    public BoardClickArea boardClickAreaPrefab;
    private Token[,,] tokens;
    private BoardClickArea[,] boardClickAreas;
    private GameObject tokenParent;
    private GameObject boardClickAreaParent;

    private void InstantiateTokens()
    {
        for (int x = 0; x < gameController.BOARD_X; x++)
        {
            for (int y = 0; y < gameController.BOARD_Y; y++)
            {
                for (int z = 0; z < gameController.BOARD_Z; z++)
                {
                    int player = gameController.GetPlayerAtIndex(x, y, z);
                    if (player == 0) continue;
                    
                    Token token = Instantiate<Token>(tokenPrefab, new Vector3(x, y, z), Quaternion.identity, this.transform);
                    token.transform.SetParent(tokenParent.transform);
                    tokens.SetValue(token, z, y, x);
                    if (player == 1) { token.color = Color.yellow; continue; }
                    token.color = Color.red;
                }
            }
        }
    }

    private void InstantiateBoardClickAreas()
    {
        for (int x = 0; x < gameController.BOARD_X; x++)
        {
            for (int y = 0; y < gameController.BOARD_Y; y++)
            {
                BoardClickArea boardClickArea = Instantiate<BoardClickArea>(boardClickAreaPrefab, boardClickAreaParent.transform);
                boardClickArea.xIdx = x;
                boardClickArea.yIdx = y;
                boardClickArea.boardHeight = gameController.BOARD_Z;
                boardClickAreas.SetValue(boardClickArea, y, x);
            }
        }
    }

    void Awake()
    {
        tokens = new Token[gameController.BOARD_Z, gameController.BOARD_Y, gameController.BOARD_X];
        boardClickAreas = new BoardClickArea[gameController.BOARD_Y, gameController.BOARD_X];

        tokenParent = new GameObject();
        tokenParent.transform.parent = transform;
        tokenParent.name = "Token Parent";

        boardClickAreaParent = new GameObject();
        boardClickAreaParent.transform.parent = transform;
        boardClickAreaParent.name = "Board Click Area Parent";
    }

    // Start is called before the first frame update
    void Start()
    {
        InstantiateBoardClickAreas();
        InstantiateTokens();
    }
}
