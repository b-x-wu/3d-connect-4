using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameContext
{
    public static int BOARD_X = 7;
    public static int BOARD_Y = 7;
    public static int BOARD_Z = 6;
    public static int PLAYER_COUNT = 2;
    public static int TOKEN_WIN_COUNT = 4;
    public static List<Color> PLAYER_COLORS = new List<Color>() {
        Color.red,
        Color.yellow,
        Color.blue,
        Color.green,
        Color.magenta,
        Color.cyan
    };
}
