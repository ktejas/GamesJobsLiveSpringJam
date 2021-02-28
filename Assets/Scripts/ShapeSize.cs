using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSize : MonoBehaviour
{
    [SerializeField] private int width = default;
    [SerializeField] private int height = default;
    [SerializeField] private int size = default;

    public void setSize(int widthParam, int heightParam)
    {
        width = widthParam;
        height = heightParam;
        size = width * height;
    }
    public int getWidth()
    {
        return width;
    }
    public int getHeight()
    {
        return height;
    }
    public int getSize()
    {
        return size;
    }
}
