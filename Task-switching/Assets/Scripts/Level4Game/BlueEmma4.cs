using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEmma4 : MonoBehaviour
{
    public void OnButtonPress()
    {
        GameObject.Find("Level4Manager").GetComponent<Level4Game>().setTrial(0);
    }
}
