using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardClickArea : MonoBehaviour
{
    public int xIdx;
    public int yIdx;
    public float boardHeight;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(xIdx, boardHeight / 2, yIdx);
        transform.localScale = new Vector3(1, boardHeight, 1);
    }
    
    void OnMouseOver()
    {
        GetComponent<MeshRenderer>().enabled = true;
        // if (Input.GetMouseButtonDown(0))
        // {
        //     GetComponent<MeshRenderer>().enabled = true;
        // }
    }

    void OnMouseExit()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
