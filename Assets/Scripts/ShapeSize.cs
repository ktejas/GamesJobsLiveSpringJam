using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSize : MonoBehaviour
{
    [SerializeField] public  int shapeSize = default;
    public void setSize(int size)
    {
        shapeSize = size;
    }
    public int getSize()
    {
        return shapeSize;
    }
}
