using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the camera can be in sphereical coordinates but the value of phi needs to be restricted
// to prevent weird flips in the camera
// make the origin on the (BOARD_X / 2, BOARD_Y / 2, 0)
// restrict epsilon < phi < pi/2

public class GameController : MonoBehaviour
{
    public int BOARD_X = 7;
    public int BOARD_Y = 7;
    public int BOARD_Z = 6;
    private int[,,] state; // TODO: should be changed to an array of player pointers
    public Board boardPrefab;

    public int GetPlayerAtIndex(int x, int y, int z)
    {
        return (int) state.GetValue(z, y, x);
    }

    // Start is called before the first frame update
    void Awake()
    {
        state = new int[BOARD_Z, BOARD_Y, BOARD_X];
        Physics.queriesHitTriggers = true;

        for (int x = 0; x < BOARD_X; x++)
        {
            for (int y = 0; y < BOARD_Y; y++)
            {
                for (int z = 0; z < BOARD_Z; z++)
                {
                    state.SetValue(1, z, y, x);
                }
            }
        }
        
    }
    
    void Start()
    {
        // set camera
        SphericalTransform cameraSphericalTransform = Camera.main.GetComponent<SphericalTransform>();
        Vector3 cameraOrigin = new Vector3(BOARD_X / 2, 0, BOARD_Y / 2);
        float radius = (new Vector3(BOARD_X / 2, BOARD_Z, BOARD_Y / 2)).magnitude;
        cameraSphericalTransform.origin = cameraOrigin;
        cameraSphericalTransform.radius = 2f * radius;
        cameraSphericalTransform.theta = Mathf.Atan(cameraOrigin.z / cameraOrigin.x);
        cameraSphericalTransform.phi = Mathf.Acos(BOARD_Z / radius);

        Camera.main.GetComponent<SphericalTransformClamp>().radiusClamp = new Vector2(0, 5f * radius);

        Camera.main.transform.rotation = Quaternion.LookRotation(cameraOrigin - Camera.main.transform.position, Vector3.up);
    }

    void Update()
    {
        Vector3 lookDirection = new Vector3(BOARD_X / 2, 0, BOARD_Y / 2) - Camera.main.transform.position;
        Camera.main.transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
    }
}
