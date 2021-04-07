using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarOk6 : MonoBehaviour
{
    public void OnButtonPress()
    {
        Debug.Log("pressed");
        if (GameObject.Find("Level6Manager").GetComponent<Level6Game>().getCurrentTrial() < GameObject.Find("Level6Manager").GetComponent<Level6Game>().getTrials())
        {
            Debug.Log("if is ok");
            GameObject.Find("Level6Manager").GetComponent<Level6Game>().showPanel(false);
            Debug.Log("show panel ok");
        }
        else
        {
            GameObject.Find("Level6Manager").GetComponent<Level6Game>().finish();
        }
    }
}
