using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarOk3 : MonoBehaviour
{
   public void OnButtonPress()
    {
        Debug.Log("pressed");
        if (GameObject.Find("Level3Manager").GetComponent<Level3Game>().getCurrentTrial() < GameObject.Find("Level3Manager").GetComponent<Level3Game>().getTrials())
        {
            Debug.Log("if is ok");
            GameObject.Find("Level3Manager").GetComponent<Level3Game>().showPanel(false);
            Debug.Log("show panel ok");
        }
        else
        {
            GameObject.Find("Level3Manager").GetComponent<Level3Game>().finish(true);
        }
    }
}
