using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropTargetB4 : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop B");
        GameObject.Find("Level4Manager").GetComponent<Level4Game>().selectB();
    }
}
