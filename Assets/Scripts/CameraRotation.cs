using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float speed = 0.1f;

    void Update()
    {
        transform.Rotate(new Vector3(0.0f, speed, 0.0f));
    }
}
