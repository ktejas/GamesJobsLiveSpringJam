using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler
{
    RectTransform rectTransform;

    public void OnMouseDown()
    {
        string[] sounds = new string[] { "BlockPickupA", "BlockPickupB", "BlockPickupC" };
        FindObjectOfType<AudioManager>().Play(sounds[Random.Range(0, 3)]);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = Vector3.zero;
    }
}
