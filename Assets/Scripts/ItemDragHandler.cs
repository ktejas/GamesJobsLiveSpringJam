using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler
{
    RectTransform rectTransform;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        Debug.Log("On Drag");
    }

    

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = Vector3.zero;
        Debug.Log("End Drag");
    }
}
