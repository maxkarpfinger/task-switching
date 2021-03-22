using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropTargetB3 : MonoBehaviour, IDropHandler
{
   public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop B");
        GameObject.Find("Level3Manager").GetComponent<Level3Game>().selectB(); ;
    }
}
