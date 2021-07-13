using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelNavigation3 : MonoBehaviour
{
    public void OnReloadScene()
    {
        // reload scene
        GameObject.Find("Level3Manager").GetComponent<Level3Game>().finish(false);
        SceneManager.LoadScene("Level3");
    }

    public void OnNextLevel()
    {
        // change to level 3 scene
        GameObject.Find("Level3Manager").GetComponent<Level3Game>().finish(false);
        SceneManager.LoadScene("Level4");
    }
}
