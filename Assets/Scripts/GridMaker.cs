using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public GameObject root;    
    void Start()
    {
        for (int i = -3; i < 4; i++){
            GameObject newLine = Instantiate(root, transform.position, Quaternion.identity, transform);
            newLine.GetComponent<LineRenderer>().useWorldSpace = false;
            newLine.GetComponent<LineRenderer>().SetPosition(0, new Vector3(i*2,0,6));
            newLine.GetComponent<LineRenderer>().SetPosition(1, new Vector3(i*2,0,-6));
        }
        for (int i = -3; i < 4; i++){
            GameObject newLine = Instantiate(root, transform.position, Quaternion.identity, transform);
            newLine.GetComponent<LineRenderer>().useWorldSpace = false;
            newLine.GetComponent<LineRenderer>().SetPosition(0, new Vector3(6,0,i*2));
            newLine.GetComponent<LineRenderer>().SetPosition(1, new Vector3(-6,0,i*2));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
