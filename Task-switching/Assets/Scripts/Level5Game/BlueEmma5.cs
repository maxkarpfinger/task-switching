using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEmma5 : MonoBehaviour
{
    public void OnButtonPress()
    {
        GameObject.Find("Level5Manager").GetComponent<Level5Game>().setTrial(0);
    }
}
