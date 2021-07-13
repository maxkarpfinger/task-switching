using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelNavigation1 : MonoBehaviour
{
    public void OnReloadScene()
    {
        // reload scene
        GameObject.Find("Level1Manager").GetComponent<Level1Game>().finish(false);
        Debug.Log("reload level");
        SceneManager.LoadScene("Level1");
    }

    public void OnNextLevel()
    {
        // change to level 2 scene
        GameObject.Find("Level1Manager").GetComponent<Level1Game>().finish(false);
        Debug.Log("reload level");
        SceneManager.LoadScene("Level2");
    }
}
