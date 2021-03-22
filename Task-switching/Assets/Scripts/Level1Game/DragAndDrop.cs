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
        //canvasGroup = GetComponent<CanvasGroup>();
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

    //public void OnMouseDown()
    //{
        //isDragging = true;
     //   Debug.Log("blocksRaycasts false");
     //   canvasGroup.blocksRaycasts = false;
        //canvasGroup.alpha = 0.1f;
    //}

    //public void OnMouseUp()
    //{
     //   Debug.Log("blocksRaycasts true");
     //   canvasGroup.blocksRaycasts = true;
        // isDragging = false;
        //canvasGroup.alpha = 1f;
    //}

    public void OnBeginDrag(PointerEventData _EventData)
    {
        //canvasGroup.blocksRaycasts = false;
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        //transform.Translate(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        //canvasGroup.blocksRaycasts = false;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        //canvasGroup.blocksRaycasts = true;
    }


}
