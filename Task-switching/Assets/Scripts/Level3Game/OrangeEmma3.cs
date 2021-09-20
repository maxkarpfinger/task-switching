using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeEmma3 : MonoBehaviour
{
    public void OnButtonPress()
    {
        GameObject.Find("Level3Manager").GetComponent<Level3Game>().setTrial(1);
    }
}
