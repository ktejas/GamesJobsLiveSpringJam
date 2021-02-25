using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YDisplay : MonoBehaviour
{
    Text text;
    public GameObject gameManager;
    void Start()
    {
        text = GetComponent<Text>();
        
    }


    void Update()
    {
        text.text = "Y Level:" + gameManager.GetComponent<GameManager>().yOffsetForDraggedObject.ToString();
    }
}
