﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeLuna : MonoBehaviour
{
    public void OnButtonPress(){
        GameObject.Find("Level1Manager").GetComponent<Level1Game>().setTrial(3);
    }
}
