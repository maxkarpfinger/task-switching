using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int levels = 0; // store the game progress
    private static GameManager instance = null; // static (class level) variable
    public static GameManager get()
    { // static getter (only accessing allowed)
        return instance; 
    }  

    private void Awake()
    {
        // if instance is not yet set, set it and make it persistent between scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // if instance is already set and this is not the same object, destroy it
            if (this != instance) { Destroy(gameObject); }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // if instance is not yet set, set it and make it persistent between scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // if instance is already set and this is not the same object, destroy it
            if (this != instance) { Destroy(gameObject); }
        }
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

    public int getLevel()
    {
        return levels;
    }
}
