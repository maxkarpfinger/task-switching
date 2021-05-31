using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int levels = 0; // store the game progress
    int page = 0; // store the page of level page {friends:0, food:1, decoration:2}
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
            levels = PlayerPrefs.GetInt("levels");
            page = PlayerPrefs.GetInt("page");
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
            levels = PlayerPrefs.GetInt("levels");
            page = PlayerPrefs.GetInt("page");
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
        PlayerPrefs.SetInt("levels", levels);
        PlayerPrefs.Save();
    }

    public void incrementProgress()
    {
        levels++;
        if (levels > 17)
        {
            levels = 17;
        }
        PlayerPrefs.SetInt("levels", levels);
        PlayerPrefs.Save();
    }

    public void reset()
    {
        levels = 0;
        PlayerPrefs.SetInt("levels", levels);
        PlayerPrefs.Save();
        Debug.Log("reset progress");
    }

    public int getLevel()
    {
        return levels;
    }

    public int getPage(){
        return page;
    }

    public void incrementPage(){
        page = page + 1;        
        //change if more than 3 pages
        if(page > 2){
            page = 2;
        }
        PlayerPrefs.SetInt("page", page);
        PlayerPrefs.Save();
        Debug.Log("Page is incremented to: "+page);
    }

    public void decrementPage(){
        page = page - 1;
        if(page < 0){
            page = 0;
        }
        PlayerPrefs.SetInt("page", page);
        PlayerPrefs.Save();
        Debug.Log("Page is decremented to: "+page);
    }
}
