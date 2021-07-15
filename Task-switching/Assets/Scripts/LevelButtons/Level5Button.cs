using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level5Button : MonoBehaviour
{
    GameObject button;

    public void OnButtonPress()
    {
        //change to level 5 scene
        SceneManager.LoadScene("Level5");
    }

    public void lockButton()
    {
        button.GetComponent<Button>().interactable = false;
    }
}
