using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float rotationSpeed = 10.0f;
    public GameManager gameManager;

    void Start()
    {
       
    }

    void Update()
    {
        // Rotating camera around a point (first parameter), around the Y axis (second parameter) at 20 degrees per second * speed
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.RotateAround(new Vector3(8.26f, 3f, 3.37f), new Vector3(0.0f, 2.0f, 0.0f), /*10 * Time.deltaTime * rotationSpeed*/ 35f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.RotateAround(new Vector3(8.26f, 3f, 3.37f), new Vector3(0.0f, 2.0f, 0.0f), /*10 * Time.deltaTime * -rotationSpeed*/ -35f);
        }

        //camera moving with y-value, doesn't work atm
        //transform.position = new Vector3(transform.position.x, (8 + gameManager.GetComponent<GameManager>().yOffsetForDraggedObject), transform.position.z);
    }
}
