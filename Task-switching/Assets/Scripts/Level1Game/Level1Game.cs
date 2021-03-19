using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Level1Game : MonoBehaviour
{
    int trial = 0;
    int correct = 0;
    int level = 0;
    static int numberOfTrials = 8;
    int[] stimulusArray = new int[numberOfTrials]; 
    bool colorGame = true;
    bool isCorrectAnswerA = true;
    bool isSelectedA = true;
    GameObject stimulus;
    GameObject targetA;
    GameObject targetB;
    GameObject trialCounter;
    GameObject starPanel;
    GameObject text;
    GameObject stars;
    //public SpriteRenderer spriteRenderer;
    string COLOR_GAME_INFO = "Lass uns gemeinsam etwas spielen. " +
        "Wir werden ein Farbenspiel spielen, " +
        "lass uns das Farbenspiel spielen.\n " +
        "Auf dem Bildschirm findest Du ein Tier:\n" +
        "Das ist die Katze Emma, Emma ist manchmal blau, und manchmal orange.\n Hilfst du " +
        "ihr, ins gleich gefärbte Kästchen(Haus oder Korb) zu finden. Deine Aufgabe ist es, Emma in ihr gefärbtes Kästchen zu begleiten.\n" +
        "Los geht's!" ;
    string SHAPE_GAME_INFO = "Lass uns gemeinsam etwas spielen. Wir werden ein Formenspiel spielen, lass uns das Formenspiel spielen.\n" +
        "Auf dem Bildschirm findest Du zwei Tiere:\n " +
        "Das ist Emma, Emma spielt gerne mit Bällen.\n" +
        "Hilfst Du ihr/ihm, den Ball zu finden.\n" +
        "Deine Aufgabe ist es, auf den Ball zu tippen, wenn Due Emma siest. \n" +
        "Das ist Luna, Luna spielt gerne mit Zweigen.Hilfst Du ihr/ihm, den Zweig zu finden. Deine Aufgabe ist es, auf den Zweig zu tippen, wenn Du Luna siest.\n " +
        "Los geht's!";
    Sprite BLUE_EMMA;
    Sprite BLUE_LUNA;
    Sprite ORANGE_LUNA;
    Sprite ORANGE_EMMA;
    Vector3 SPRITE_DEFAULT_POS;

    // Start is called before the first frame update
    void Start()
    {
        stimulus = GameObject.Find("Stimulus_1");
        //spriteRenderer = GameObject.Find("blue_emma").GetComponent<SpriteRenderer>();
        targetA = GameObject.Find("TargetA_1");
        targetB = GameObject.Find("TargetB_1");
        trialCounter = GameObject.Find("TrialCounter_1");
        starPanel = GameObject.Find("StarPanel1");
        text = GameObject.Find("StarAmount_1");
        starPanel.SetActive(true);
        text.GetComponent<Text>().text = COLOR_GAME_INFO;
        BLUE_EMMA = Resources.Load<Sprite>("blue_emma");
        ORANGE_EMMA = Resources.Load<Sprite>("orange_emma");
        SPRITE_DEFAULT_POS = stimulus.transform.position;
        stars = GameObject.Find("stars_achieved");
        stars.SetActive(false);

        for (int i=0; i<numberOfTrials; i++)
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
        //only color game
        Debug.Log("Trial is "+ (trial+1).ToString()+", stimulus is " + stimulusArray[trial].ToString());
        if (stimulusArray[trial] == 0)
        {
            //spriteRenderer.sprite = BLUE_EMMA;
            stimulus.GetComponent<Image>().sprite = BLUE_EMMA;
            isCorrectAnswerA = true;
        }
        else
        {
            //spriteRenderer.sprite = ORANGE_EMMA;
            stimulus.GetComponent<Image>().sprite = ORANGE_EMMA;
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
        string number = GameObject.Find("Level1Manager").GetComponent<Level1Game>().getCorrect().ToString();
        string max = GameObject.Find("Level1Manager").GetComponent<Level1Game>().getTrials().ToString();
        starPanel.SetActive(true);
        stars.SetActive(true);

        if (correct == numberOfTrials)
        {
            stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("5_stars");
        }
        if (correct*1.0/numberOfTrials < 1)
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
