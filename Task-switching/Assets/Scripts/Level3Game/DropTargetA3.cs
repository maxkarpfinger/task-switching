using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropTargetA3 : MonoBehaviour, IDropHandler
{
  public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop A");
        GameObject.Find("Level3Manager").GetComponent<Level3Game>().selectA(); ;
    }
}
