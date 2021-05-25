using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNavigation : MonoBehaviour
{
   public void left()
    {
        GameObject.Find("TutorialManager").GetComponent<TutorialManager>().onLeft();
    }

    public void right()
    {
        GameObject.Find("TutorialManager").GetComponent<TutorialManager>().onRight();
    }
}
