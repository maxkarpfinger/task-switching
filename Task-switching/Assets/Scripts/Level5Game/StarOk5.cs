using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarOk5 : MonoBehaviour
{
    public void OnButtonPress()
    {
        Debug.Log("pressed");
        if (GameObject.Find("Level5Manager").GetComponent<Level5Game>().getCurrentTrial() < GameObject.Find("Level5Manager").GetComponent<Level5Game>().getTrials())
        {
            Debug.Log("if is ok");
            GameObject.Find("Level5Manager").GetComponent<Level5Game>().showPanel(false);
            Debug.Log("show panel ok");
        }
        else
        {
            GameObject.Find("Level5Manager").GetComponent<Level5Game>().finish();
        }
    }
}
