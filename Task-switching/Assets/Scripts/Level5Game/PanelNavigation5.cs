using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelNavigation5 : MonoBehaviour
{
    public void OnReloadScene()
    {
        // reload scene
        GameObject.Find("Level5Manager").GetComponent<Level5Game>().finish(false);
        SceneManager.LoadScene("Level5");
    }

    public void OnNextLevel()
    {
        // change to level 6 scene
        GameObject.Find("Level5Manager").GetComponent<Level5Game>().finish(false);
        SceneManager.LoadScene("Level6");
    }
}
