using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameController gameController;
    public float startingRadiusMultiplier = 2f;
    public float radiusScaleSpeed = 1f;
    public float thetaScaleSpeed = 1f;
    public float phiScaleSpeed = 1f;
    private SphericalTransform sphericalTransform;
    private SphericalTransformClamp sphericalTransformClamp;
    private Vector3 cameraOrigin;

    void Start()
    {
        sphericalTransform = GetComponent<SphericalTransform>();
        sphericalTransformClamp = GetComponent<SphericalTransformClamp>();
        cameraOrigin = new Vector3(gameController.BOARD_X / 2, 0, gameController.BOARD_Y / 2);
        
        float radius = (new Vector3(gameController.BOARD_X / 2, gameController.BOARD_Z, gameController.BOARD_Y / 2)).magnitude;

        sphericalTransform.origin = cameraOrigin;
        sphericalTransform.radius = startingRadiusMultiplier * radius;
        sphericalTransform.theta = Mathf.Atan(cameraOrigin.z / cameraOrigin.x);
        sphericalTransform.phi = Mathf.Acos(gameController.BOARD_Z / radius);

        sphericalTransformClamp.radiusClamp = new Vector2(sphericalTransformClamp.radiusClamp.x, startingRadiusMultiplier * startingRadiusMultiplier * radius);

        transform.rotation = Quaternion.LookRotation(cameraOrigin - transform.position, Vector3.up); 
    }

    void Update()
    {
        Vector3 lookDirection = new Vector3(gameController.BOARD_X / 2, 0, gameController.BOARD_Y / 2) - transform.position;
        transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        sphericalTransform.radius -= Input.mouseScrollDelta.y * radiusScaleSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            sphericalTransform.theta -= Time.deltaTime * thetaScaleSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            sphericalTransform.theta += Time.deltaTime * thetaScaleSpeed;
        }
    
        if (Input.GetKey(KeyCode.W))
        {
            sphericalTransform.phi -= Time.deltaTime * phiScaleSpeed;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            sphericalTransform.phi += Time.deltaTime * phiScaleSpeed;
        }
    }
}
