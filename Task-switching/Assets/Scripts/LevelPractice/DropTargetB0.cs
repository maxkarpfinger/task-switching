using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropTargetB0 : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //reversed in practice
        Debug.Log("OnDrop B");
        GameObject.Find("LevelPracticeManager").GetComponent<LevelPracticeManager>().selectB(); ;
    }
}

