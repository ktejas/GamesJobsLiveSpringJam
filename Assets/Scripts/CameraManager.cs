using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float rotationSpeed = 10.0f;
    public GameManager gameManager;
    private static bool cameraInverted = false;

    void Start()
    {
       
    }

    void Update()
    {
        // Rotating camera around a point (first parameter), around the Y axis (second parameter) at 20 degrees per second * speed
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!cameraInverted)
            {
                transform.RotateAround(new Vector3(8.26f, 3f, 3.37f), new Vector3(0.0f, 2.0f, 0.0f), 35f);
            }
            else
            {
                transform.RotateAround(new Vector3(8.26f, 3f, 3.37f), new Vector3(0.0f, 2.0f, 0.0f), -35f);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!cameraInverted)
            {
                transform.RotateAround(new Vector3(8.26f, 3f, 3.37f), new Vector3(0.0f, 2.0f, 0.0f), -35f);
            }
            else
            {
                transform.RotateAround(new Vector3(8.26f, 3f, 3.37f), new Vector3(0.0f, 2.0f, 0.0f), 35f);
            }
        }
    }

    public void setCameraInverted()
    {
        if (cameraInverted)
        {
            cameraInverted = false;
        } else 
        {
            cameraInverted = true;
        }
    }
}
