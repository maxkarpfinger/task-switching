using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropTargetB2 : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop B");
        GameObject.Find("Level2Manager").GetComponent<Level2Game>().selectB(); ;
    }
}

