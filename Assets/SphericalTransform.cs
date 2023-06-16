using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalTransform : MonoBehaviour
{
    [Tooltip("Center of the spherical coordinate system")]
    public Vector3 center;

    [Tooltip("Radius of the spherical coordinate system")]
    public float radius;
    
    [Tooltip("Angle from the positive x axis in radians on the xy plane")]
    public float theta;
    
    [Tooltip("Angle made with the positive z axis")]
    public float phi;

    [Tooltip("Maximum allowed radius.")]
    public float maxRadius = float.MaxValue;

    void UpdateTransform()
    {
        radius = Mathf.Abs(radius);
        if (radius > maxRadius) radius = maxRadius;
        transform.position = new Vector3(radius * Mathf.Sin(theta) * Mathf.Cos(phi) + center.x, radius * Mathf.Sin(theta) * Mathf.Cos(phi) + center.y, radius * Mathf.Cos(theta) + center.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTransform();
    }

    void OnValidate()
    {
        UpdateTransform();
    }
}
