using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarOk4 : MonoBehaviour
{
    public void OnButtonPress()
    {
        Debug.Log("pressed");
        if (GameObject.Find("Level4Manager").GetComponent<Level4Game>().getCurrentTrial() < GameObject.Find("Level4Manager").GetComponent<Level4Game>().getTrials())
        {
            Debug.Log("if is ok");
            GameObject.Find("Level4Manager").GetComponent<Level4Game>().showPanel(false);
            Debug.Log("show panel ok");
        }
        else
        {
            GameObject.Find("Level4Manager").GetComponent<Level4Game>().finish(true);
        }
    }
}
