using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardClickArea : MonoBehaviour
{
    public int xIdx;
    public int yIdx;
    public float boardHeight;
    public GameController gameController;

    void Start()
    {
        transform.position = new Vector3(xIdx, boardHeight / 2 - 0.5f, yIdx);
        transform.localScale = new Vector3(1, boardHeight, 1);
    }
    
    void OnMouseOver()
    {
        GetComponent<MeshRenderer>().enabled = true;
        if (Input.GetMouseButtonDown(0))
        {
            gameController.HandleBoardClick(xIdx, yIdx);
        }
    }

    void OnMouseExit()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
