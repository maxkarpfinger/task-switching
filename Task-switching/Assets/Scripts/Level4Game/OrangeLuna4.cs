using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeLuna4 : MonoBehaviour
{
    public void OnButtonPress()
    {
        GameObject.Find("Level4Manager").GetComponent<Level4Game>().setTrial(3);
    }
}
