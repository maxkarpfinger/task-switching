using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private bool isDragging;
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
           // transform.Translate(mousePosition);
        }
    }

    public void OnMouseDown()
    {
        //isDragging = true;
        //canvasGroup.blocksRaycasts = false;
        //canvasGroup.alpha = 0.1f;
    }

    public void OnMouseUp()
    {
       // isDragging = false;
       // canvasGroup.blocksRaycasts = true;
        //canvasGroup.alpha = 1f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        //transform.Translate(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }


}
