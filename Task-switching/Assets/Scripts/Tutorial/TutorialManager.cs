using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    int page = 0;
    int numberOfPages = 3;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        refreshInterface();
        playExplanation();
    }

    public void onLeft()
    {
        Debug.Log("onLeft");
        Debug.Log("page is:" + page);
        page = page - 1;
        if(page < 0)
        {
            Debug.Log("underflow");
            page = 0;
        }
        refreshInterface();
        playExplanation();
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
        playExplanation();
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

    public void playExplanation()
    {
        if(page == 0)
        {
            var clip = Resources.Load("leo") as AudioClip;
            audioSource.clip = clip;
            audioSource.Play();
        }
        if (page == 1)
        {
            var clip = Resources.Load("correct") as AudioClip;
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
