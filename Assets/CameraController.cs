using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameController gameController;
    
    void Start()
    {
        SphericalTransform cameraSphericalTransform = GetComponent<SphericalTransform>();
        Vector3 cameraOrigin = new Vector3(gameController.BOARD_X / 2, 0, gameController.BOARD_Y / 2);
        float radius = (new Vector3(gameController.BOARD_X / 2, gameController.BOARD_Z, gameController.BOARD_Y / 2)).magnitude;

        cameraSphericalTransform.origin = cameraOrigin;
        cameraSphericalTransform.radius = 2f * radius;
        cameraSphericalTransform.theta = Mathf.Atan(cameraOrigin.z / cameraOrigin.x);
        cameraSphericalTransform.phi = Mathf.Acos(gameController.BOARD_Z / radius);

        GetComponent<SphericalTransformClamp>().radiusClamp = new Vector2(0, 5f * radius);

        transform.rotation = Quaternion.LookRotation(cameraOrigin - transform.position, Vector3.up); 
    }

    void Update()
    {
        Vector3 lookDirection = new Vector3(gameController.BOARD_X / 2, 0, gameController.BOARD_Y / 2) - transform.position;
        transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
    }
}
