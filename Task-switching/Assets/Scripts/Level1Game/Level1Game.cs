using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Game : MonoBehaviour
{
    int trial = 0;
    int correct = 0;
    int numberOfTrials = 4;
    bool colorGame = true;
    bool isCorrectAnswerA = true;
    bool isSelectedA = true;
    GameObject stimulus;
    GameObject targetA;
    GameObject targetB;
    GameObject trialCounter;
    GameObject starPanel;
    GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        stimulus = GameObject.Find("Stimulus_1");
        targetA = GameObject.Find("TargetA_1");
        targetB = GameObject.Find("TargetB_1");
        trialCounter = GameObject.Find("TrialCounter_1");
        starPanel = GameObject.Find("StarPanel1");
        text = GameObject.Find("StarAmount_1");
        starPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkCorrectnes()
    {
        bool trialIsCorrect = isCorrectAnswerA && isSelectedA;
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
        if(trial >= numberOfTrials)
        {
            showStars();
            return;
        }
        trialCounter.GetComponent<Text>().text = (trial +1).ToString();
        setupTrial();
    }

    public void setupTrial()
    {
        //set correct answer and update stimulus
        if (colorGame)
        {

        }
        else
        {

        }
    }

    public void finish()
    {
        //return to level page
        if (correct == numberOfTrials)
        {
            GameManager.get().incrementProgress();
        }
        SceneManager.LoadScene("LevelPage");
    }

    public void showStars()
    {
        //display number of won stars
        //also give audio feedback
        show();
        //finish();
    }

    public void selectA()
    {
        isSelectedA = true;
        checkCorrectnes();
    }

    public void selectB()
    {
        isSelectedA = false;
        checkCorrectnes();
    }

    public int getCorrect()
    {
        return correct;
    }

    public int getTrials()
    {
        return numberOfTrials;
    }

    public void show()
    {
        string prefix = "Du hast ";
        string mid = " von ";
        string suffix = " Sternen bekommen!";
        string number = GameObject.Find("Level1Manager").GetComponent<Level1Game>().getCorrect().ToString();
        string max = GameObject.Find("Level1Manager").GetComponent<Level1Game>().getTrials().ToString();
        starPanel.SetActive(true);
        text.GetComponent<Text>().text = prefix + number + mid + max + suffix;
    }
}
