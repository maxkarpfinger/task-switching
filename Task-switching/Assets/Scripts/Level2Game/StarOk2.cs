using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarOk2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPress()
    {
        Debug.Log("pressed");
        if (GameObject.Find("Level2Manager").GetComponent<Level2Game>().getCurrentTrial() < GameObject.Find("Level2Manager").GetComponent<Level2Game>().getTrials())
        {
            Debug.Log("if is ok");
            GameObject.Find("Level2Manager").GetComponent<Level2Game>().showPanel(false);
            Debug.Log("show panel ok");
        }
        else
        {
            GameObject.Find("Level2Manager").GetComponent<Level2Game>().finish();
        }
    }
}