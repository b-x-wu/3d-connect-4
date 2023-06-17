using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphericalTransform))]
public class SphericalTransformClamp : MonoBehaviour
{
    public Vector2 radiusClamp = new Vector2(0, float.MaxValue);
    public Vector2 thetaClamp = new Vector2(0, 2*Mathf.PI);
    public Vector2 phiClamp = new Vector2(0, Mathf.PI);
}
