using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float rotationSpeed = 10.0f;

    private Vector3 startPosition;

    void Start()
    {
        // Camera rotates around center
        //transform.LookAt(new Vector3(8.26f, 3f, 3.37f));
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotating camera around a point (first parameter), around the Y axis (second parameter) at 20 degrees per second * speed
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(startPosition, new Vector3(0.0f, 2.0f, 0.0f), 10 * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(startPosition, new Vector3(0.0f, 2.0f, 0.0f), 10 * Time.deltaTime * -rotationSpeed);
        }

        // Increasing/decreasing height of camera
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0.01f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, 0.01f, 0);
        }
    }
}
