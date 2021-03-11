﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level5Button : MonoBehaviour
{
    int level = 4;
    GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Level5Button");
        if (GameManager.get().getLevel() < level)
        {
            lockButton();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPress()
    {
        //change to level 5 scene
    }

    public void lockButton()
    {
        button.GetComponent<Button>().interactable = false;
    }
}