using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropBehaviour : MonoBehaviour, IDropHandler
{
   public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop A");
        GameObject.Find("Level1Manager").GetComponent<Level1Game>().selectA(); ;
    }
}
