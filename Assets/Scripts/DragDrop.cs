using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    //private DragController dragController;
    public GameObject[] blocks;
    private int generatedBlockIndex = 0;
    public Sprite[] blockSprites;
    private Image image;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //dragController = GetComponent<DragController>();
        //dragController.enabled = false;
        generatedBlockIndex = 0;
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        //dragController.enabled = true;
        rectTransform.localPosition = Vector3.zero;
        Instantiate(blocks[generatedBlockIndex], Input.mousePosition, Quaternion.identity);
        GenerateRandomBlock();
        StartCoroutine(GenerateItem());

        image.color = new Color(1.0f,1.0f,1.0f,0.0f);
        //Destroy(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

    void GenerateRandomBlock()
    {
        int rand = Random.Range(0, 5);
        generatedBlockIndex = rand;
    }

    IEnumerator GenerateItem()
    {
        yield return new WaitForSeconds(2.0f);
        image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        image.sprite = blockSprites[generatedBlockIndex];
    }
}
