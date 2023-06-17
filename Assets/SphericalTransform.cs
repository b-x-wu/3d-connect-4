using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalTransform : MonoBehaviour
{
    public Vector3 origin;
    public float radius;
    public float phi;
    public float theta;
    private SphericalTransformClamp sphericalTransformClamp;

    void ClampValues()
    {
        radius = Mathf.Clamp(radius, sphericalTransformClamp.radiusClamp.x, sphericalTransformClamp.radiusClamp.y);
        theta = Mathf.Clamp(theta, sphericalTransformClamp.thetaClamp.x, sphericalTransformClamp.thetaClamp.y);
        phi = Mathf.Clamp(phi, sphericalTransformClamp.phiClamp.x, sphericalTransformClamp.phiClamp.y);
    }

    void UpdateTransform()
    {
        float x = radius * Mathf.Sin(phi) * Mathf.Cos(theta) + origin.x;
        float y = radius * Mathf.Cos(phi) + origin.y;
        float z = radius * Mathf.Sin(phi) * Mathf.Sin(theta) + origin.z;
        transform.position = new Vector3(x, y, z);
    }

    void Awake()
    {
        sphericalTransformClamp = GetComponent<SphericalTransformClamp>();
    }

    void OnUpdate()
    {
        if (sphericalTransformClamp != null) ClampValues();
        UpdateTransform();
    }

    void OnValidate()
    {
        if ((sphericalTransformClamp = GetComponent<SphericalTransformClamp>()) != null) ClampValues();
        UpdateTransform();
    }
}
