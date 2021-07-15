using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level4Button : MonoBehaviour
{
    GameObject button;

    public void OnButtonPress()
    {
        //change to level 4 scene
        SceneManager.LoadScene("Level4");
    }

    public void lockButton()
    {
        button.GetComponent<Button>().interactable = false;
    }
}
