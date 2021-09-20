using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeLuna2 : MonoBehaviour
{
    public void OnButtonPress()
    {
        GameObject.Find("Level2Manager").GetComponent<Level2Game>().setTrial(3);
    }
}
