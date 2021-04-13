using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3Button : MonoBehaviour
{
    int level = 2;
    GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        /*button = GameObject.Find("Level3Button");
        if (GameManager.get().getLevel() < level)
        {
            lockButton();
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

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
