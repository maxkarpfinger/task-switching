using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelNavigation4 : MonoBehaviour
{
    public void OnReloadScene()
    {
        // reload scene
        GameObject.Find("Level4Manager").GetComponent<Level4Game>().finish(false);
        SceneManager.LoadScene("Level4");
    }

    public void OnNextLevel()
    {
        // change to level 5 scene
        GameObject.Find("Level4Manager").GetComponent<Level4Game>().finish(false);
        SceneManager.LoadScene("Level5");
    }
}
