using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelNavigation2: MonoBehaviour
{
    public void OnReloadScene()
    {
        // reload scene
        GameObject.Find("Level2Manager").GetComponent<Level2Game>().finish(false);
        SceneManager.LoadScene("Level2");
    }

    public void OnNextLevel()
    {
        // change to level 3 scene
        GameObject.Find("Level2Manager").GetComponent<Level2Game>().finish(false);
        SceneManager.LoadScene("Level3");
    }
}
