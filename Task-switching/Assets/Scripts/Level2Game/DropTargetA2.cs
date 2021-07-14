﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropTargetA2 : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //reversed in practice
        Debug.Log("OnDrop A");
        GameObject.Find("Level2Manager").GetComponent<Level2Game>().selectA(); ;
    }
}

