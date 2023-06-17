using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    // Start is called before the first frame update
    private Color _color = Color.clear;
    public Color color { get => _color; set => SetColor(value); }
    void Start()
    {
        SetColor(_color);
    }

    public void SetColor(Color color)
    {
        _color = color;
        GetComponent<MeshRenderer>().material.color = color;
    }
}
