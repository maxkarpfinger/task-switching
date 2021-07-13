using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Button : MonoBehaviour
{

    public void OnButtonPress()
    {
        //change to level 2 scene
        SceneManager.LoadScene("Level2");
    }
}
