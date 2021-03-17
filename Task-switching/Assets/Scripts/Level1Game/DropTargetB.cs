using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropTargetB : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop B");
        GameObject.Find("Level1Manager").GetComponent<Level1Game>().selectB(); ;
    }
}
