using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public IntegerInputField boardXInput;
    public IntegerInputField boardYInput;
    public IntegerInputField boardZInput;
    public IntegerInputField tokenWinCountInput;
    public IntegerInputField playerCountInput;

    void Start()
    {
        boardXInput.SetCurrentValue(GameContext.BOARD_X);
        boardYInput.SetCurrentValue(GameContext.BOARD_Y);
        boardZInput.SetCurrentValue(GameContext.BOARD_Z);
        tokenWinCountInput.SetCurrentValue(GameContext.TOKEN_WIN_COUNT);
        playerCountInput.SetCurrentValue(GameContext.PLAYER_COUNT);
    }

    public void OnBoardXInputChange()
    {
        if (boardXInput.currentValue <= 0)
        {
            boardXInput.SetCurrentValue(GameContext.BOARD_X);
            return;
        }
        GameContext.BOARD_X = boardXInput.currentValue;
    }

    public void OnBoardYInputChange()
    {
        if (boardYInput.currentValue <= 0)
        {
            boardYInput.SetCurrentValue(GameContext.BOARD_Y);
            return;
        }
        GameContext.BOARD_Y = boardYInput.currentValue;
    }

    public void OnBoardZInputChange()
    {
        if (boardZInput.currentValue <= 0)
        {
            boardZInput.SetCurrentValue(GameContext.BOARD_Z);
            return;
        }
        GameContext.BOARD_Z = boardZInput.currentValue;
    }

    public void OnPlayerCountInputChange()
    {
        if (playerCountInput.currentValue < 2 || playerCountInput.currentValue > 6)
        {
            playerCountInput.SetCurrentValue(GameContext.PLAYER_COUNT);
            return;
        }
        GameContext.PLAYER_COUNT = playerCountInput.currentValue;
    }

    public void OnTokenWinCountInputChange()
    {
        if (tokenWinCountInput.currentValue < 1 || tokenWinCountInput.currentValue > Mathf.Max(GameContext.BOARD_X, GameContext.BOARD_Y, GameContext.BOARD_Z))
        {
            tokenWinCountInput.SetCurrentValue(GameContext.TOKEN_WIN_COUNT);
        }
        GameContext.TOKEN_WIN_COUNT = tokenWinCountInput.currentValue;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
