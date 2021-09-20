using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeEmma4 : MonoBehaviour
{
    public void OnButtonPress()
    {
        GameObject.Find("Level4Manager").GetComponent<Level4Game>().setTrial(1);
    }
}
