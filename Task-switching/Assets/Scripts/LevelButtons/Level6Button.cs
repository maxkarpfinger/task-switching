using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level6Button : MonoBehaviour
{
    GameObject button;

    public void OnButtonPress()
    {
        //change to level 6 scene
        SceneManager.LoadScene("Level6");
    }

    public void lockButton()
    {
        button.GetComponent<Button>().interactable = false;
    }
}