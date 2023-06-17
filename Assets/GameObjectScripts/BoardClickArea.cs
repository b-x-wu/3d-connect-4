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
        transform.position = new Vector3(xIdx, yIdx, boardHeight / 2);
        transform.localScale = new Vector3(1, 1, boardHeight);
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
