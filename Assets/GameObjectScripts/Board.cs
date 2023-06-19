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

    private BoardClickArea CreateBoardClickArea(int xIdx, int yIdx)
    {
        BoardClickArea boardClickArea = Instantiate<BoardClickArea>(boardClickAreaPrefab, boardClickAreaParent.transform);
        boardClickArea.xIdx = xIdx;
        boardClickArea.yIdx = yIdx;
        boardClickArea.boardHeight = gameController.BOARD_Z;
        boardClickArea.gameController = gameController;
        boardClickArea.name = $"Board Click Area ({xIdx}, {yIdx})";
        boardClickAreas.SetValue(boardClickArea, yIdx, xIdx);
        return boardClickArea;
    }

    private Token CreateToken(int xIdx, int yIdx, int zIdx, Color color)
    {
        Token token = Instantiate<Token>(tokenPrefab, new Vector3(xIdx, zIdx, yIdx), Quaternion.identity, tokenParent.transform);
        token.color = color;
        tokens.SetValue(token, zIdx, yIdx, xIdx);
        token.name = $"Token ({xIdx}, {yIdx}, {zIdx})";
        return token;
    }

    private void InitializeTokens()
    {
        for (int x = 0; x < gameController.BOARD_X; x++)
        {
            for (int y = 0; y < gameController.BOARD_Y; y++)
            {
                for (int z = 0; z < gameController.BOARD_Z; z++)
                {
                    Player player = gameController.GetPlayerAtIndex(x, y, z);
                    if (player == null) continue;
                    CreateToken(x, y, z, player.color);
                }
            }
        }
    }

    private void InitializeBoardClickAreas()
    {
        for (int x = 0; x < gameController.BOARD_X; x++)
        {
            for (int y = 0; y < gameController.BOARD_Y; y++)
            {
                CreateBoardClickArea(x, y);
            }
        }
    }

    private void HandleTokenAdded(int xIdx, int yIdx, int zIdx, Player player)
    {
        CreateToken(xIdx, yIdx, zIdx, player.color);
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

        gameController.TokenAdded += HandleTokenAdded;
    }

    void Start()
    {
        InitializeBoardClickAreas();
        InitializeTokens();
    }
}
