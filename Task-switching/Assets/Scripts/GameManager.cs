using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int levels = 0; // store the game progress
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update the game progress
    public void setGameProgress(int level)
    {
        levels = level; 
    }

    public void incrementProgress()
    {
        levels++;
        if (levels > 4)
        {
            levels = 4;
        }
    }

    public void reset()
    {
        levels = 0;
        Debug.Log("reset progress");
    }
}
