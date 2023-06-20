using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour
{
    public int xBoardLength;
    public int yBoardLength;
    public GameObject oddTile;
    public GameObject evenTile;

    public void SetTiles()
    {
        for (int i = 0; i < xBoardLength; i++)
        {
            for (int j = 0; j < yBoardLength; j++)
            {
                Instantiate<GameObject>((i + j) % 2 == 0 ? evenTile : oddTile, new Vector3(i, -0.5f, j), Quaternion.identity, transform);
            }
        }
    }
}
