using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetA_1 : MonoBehaviour, IDropHandler
{
    GameObject level; 
    // Start is called before the first frame update
    void Start()
    {
        //level = GameObject.FindGameObjectsWithTag("Level1Object")[0];
        level = GameObject.Find("Level1Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
    {
        level.GetComponent<Level1Game>().selectA();
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnButtonPress();
        Debug.Log("OnDrop");
    }

    public void OnMouseUp()
    {
        OnButtonPress();
    }
}
