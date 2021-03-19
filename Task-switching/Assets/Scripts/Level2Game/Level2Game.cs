using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Level2Game : MonoBehaviour
{
    int trial = 0;
    int correct = 0;
    int level = 1;
    static int numberOfTrials = 8;
    int[] stimulusArray = new int[numberOfTrials];
    bool colorGame = false;
    bool isCorrectAnswerA = true;
    bool isSelectedA = true;
    GameObject stimulus;
    GameObject targetA;
    GameObject targetB;
    GameObject trialCounter;
    GameObject starPanel;
    GameObject text;
    GameObject stars;
    string SHAPE_GAME_INFO = "Lass uns gemeinsam etwas spielen. Wir werden ein Formenspiel spielen, lass uns das Formenspiel spielen.\n" +
        "Auf dem Bildschirm findest Du zwei Formen:\n " +
        "Das ist Emma, Emma ist eine Katze.\n" +
        "Hilfst Du ihr zu den anderen Katzen zu kommen?.\n" +
        "Deine Aufgabe ist es, Emma zu den anderen Katzen(Haus) zu ziehen wenn du Emma siehst.\n" +
        "Das ist ein Schiff. Hilfst du dem Schiff aus Meer zu finden. Deine Aufgabe ist es, das Schiff auf das Meer zu bringen, wenn du das Schiff siehst.\n " +
        "Los geht's!";
    Sprite SHIP;
    Sprite GRAY_EMMA;
    Vector3 SPRITE_DEFAULT_POS;

    // Start is called before the first frame update
    void Start()
    {
        stimulus = GameObject.Find("Stimulus_1");
        //spriteRenderer = GameObject.Find("blue_emma").GetComponent<SpriteRenderer>();
        targetA = GameObject.Find("TargetA_1_D");
        targetB = GameObject.Find("TargetB_1_D");
        trialCounter = GameObject.Find("TrialCounter_1");
        starPanel = GameObject.Find("StarPanel1");
        text = GameObject.Find("StarAmount_1");
        starPanel.SetActive(true);
        text.GetComponent<Text>().text = SHAPE_GAME_INFO;
        SHIP = Resources.Load<Sprite>("noColor_ship");
        GRAY_EMMA = Resources.Load<Sprite>("gray_emma");
        SPRITE_DEFAULT_POS = stimulus.transform.position;
        stars = GameObject.Find("stars_achieved");
        stars.SetActive(false);

        for (int i = 0; i < numberOfTrials; i++)
        {
            int numb = Random.Range(0, 2);
            stimulusArray[i] = numb;
        }
        setupTrial();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkCorrectnes()
    {
        bool trialIsCorrect = isCorrectAnswerA && isSelectedA || !isCorrectAnswerA && !isSelectedA;
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
        //if (trial == 2)
        //{
        //    colorGame = false;
        //    starPanel.SetActive(true);
        //    text.GetComponent<Text>().text = SHAPE_GAME_INFO;
        //}
        if (trial >= numberOfTrials)
        {
            showStars();
            return;
        }
        trialCounter.GetComponent<Text>().text = (trial + 1).ToString();
        setupTrial();
    }

    public void setupTrial()
    {
        //set correct answer and update stimulus
        //only color game
        Debug.Log("Trial is " + (trial + 1).ToString() + ", stimulus is " + stimulusArray[trial].ToString());
        if (stimulusArray[trial] == 0)
        {
            //spriteRenderer.sprite = BLUE_EMMA;
            stimulus.GetComponent<Image>().sprite = SHIP;
            isCorrectAnswerA = true;
        }
        else
        {
            //spriteRenderer.sprite = ORANGE_EMMA;
            stimulus.GetComponent<Image>().sprite = GRAY_EMMA;
            isCorrectAnswerA = false;
        }
        //reset stimulus to origin position
        stimulus.transform.position = SPRITE_DEFAULT_POS;
    }

    public void finish()
    {
        //return to level page
        if (correct == numberOfTrials && GameManager.get().getLevel() == level)
        {
            GameManager.get().incrementProgress();
        }
        SceneManager.LoadScene("LevelPage");
    }

    public void showStars()
    {
        //display number of won stars
        //also give audio feedback
        string prefix = "Du hast ";
        string mid = " von ";
        string suffix = " Tests bestanden!";
        string number = GameObject.Find("Level2Manager").GetComponent<Level2Game>().getCorrect().ToString();
        string max = GameObject.Find("Level2Manager").GetComponent<Level2Game>().getTrials().ToString();
        starPanel.SetActive(true);
        stars.SetActive(true);

        if (correct == numberOfTrials)
        {
            stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("5_stars");
        }
        if (correct * 1.0 / numberOfTrials < 1)
        {
            stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("4_stars");
        }
        if (correct * 1.0 / numberOfTrials <= 0.625)
        {
            stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("3_stars");
        }
        if (correct * 1.0 / numberOfTrials <= 0.375)
        {
            stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("2_stars");
        }
        if (correct * 1.0 / numberOfTrials <= 0.125)
        {
            stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("1_star");
        }
        text.GetComponent<Text>().text = prefix + number + mid + max + suffix;
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

    public void showPanel(bool b)
    {
        starPanel.SetActive(b);
    }

    public int getCorrect()
    {
        return correct;
    }

    public int getTrials()
    {
        return numberOfTrials;
    }

    public int getCurrentTrial()
    {
        return trial;
    }


}
