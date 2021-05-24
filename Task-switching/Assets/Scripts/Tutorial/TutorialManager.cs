using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    int page = 0;
    int numberOfPages = 3;

    void Start()
    {
        
        refreshInterface();
    }

    public void onLeft()
    {
        Debug.Log("onLeft");
        page = page - 1;
        if(page < 0)
        {
            page = 0;
        }
        refreshInterface();
    }

    public void onRight()
    {
        Debug.Log("onRight");
        page = page + 1;
        if(page >= numberOfPages)
        {
            page = numberOfPages - 1;
        }
        refreshInterface();
    }

    public void refreshInterface()
    {
        Debug.Log("page:" + page);
        if (page == 0)
        {
            GameObject.Find("LeftTutorial").GetComponent<Button>().interactable = false;
            GameObject.Find("RightTutorial").GetComponent<Button>().interactable = true;
        }
        else if(page == numberOfPages - 1)
        {
            GameObject.Find("LeftTutorial").GetComponent<Button>().interactable = true;
            GameObject.Find("RightTutorial").GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject.Find("LeftTutorial").GetComponent<Button>().interactable = true;
            GameObject.Find("RightTutorial").GetComponent<Button>().interactable = true;
        }
    }
}
