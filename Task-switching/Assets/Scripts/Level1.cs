using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    int trial = 0;
    int correct = 0;
    int numberOfTrials = 4;
    bool colorGame = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkCorrectnes()
    {
        bool trialIsCorrect = false;
        //check according to type of game and chosen image
        if (trialIsCorrect)
        {
            correct++;
        }
        else
        {
            //give feedback
        }
        nextTrial();
    }

    public void nextTrial()
    {
        //
        trial++;
        if (trial == 2)
        {
            colorGame = false;
        }
        if(trial >= 4)
        {
            finish();
        }
    }

    public void finish()
    {
        showStars();
    }

    public void showStars()
    {
        //display number of won stars
        //also give audio feedback
        //return to level page button
    }
}
