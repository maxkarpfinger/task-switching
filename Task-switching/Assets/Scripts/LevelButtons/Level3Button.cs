using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3Button : MonoBehaviour
{
    GameObject button;

    public void OnButtonPress()
    {
        //change to level 3 scene
        SceneManager.LoadScene("Level3");
    }

    public void lockButton()
    {
        button.GetComponent<Button>().interactable = false;
    }
}
