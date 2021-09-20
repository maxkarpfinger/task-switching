using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeEmma6 : MonoBehaviour
{
    public void OnButtonPress()
    {
        GameObject.Find("Level6Manager").GetComponent<Level6Game>().setTrial(1);
    }
}
