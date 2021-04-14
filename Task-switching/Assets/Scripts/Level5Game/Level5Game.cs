using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Level5Game : MonoBehaviour
{
    int trial = 0;
    int correct = 0;
    int level = 4;
    static int numberOfTrials = 6;
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
    string COLOR_GAME_INFO = "Lass uns gemeinsam etwas spielen. " +
        "Wir werden ein Farbenspiel spielen, " +
        "lass uns das Farbenspiel spielen.\n " +
        "Auf dem Bildschirm findest Du ein Tier:\n" +
        "Das ist die Katze Emma, Emma ist manchmal blau, und manchmal orange.\n Hilfst du " +
        "ihr, ins gleich gefärbte Kästchen(Haus oder Korb) zu finden. Deine Aufgabe ist es, Emma in ihr gefärbtes Kästchen zu begleiten.\n" +
        "Los geht's!";
    string SHAPE_GAME_INFO = "Lass uns gemeinsam etwas spielen. Wir werden ein Formenspiel spielen, lass uns das Formenspiel spielen.\n" +
        "Auf dem Bildschirm findest Du zwei Formen:\n " +
        "Das ist Emma, Emma ist eine Katze.\n" +
        "Hilfst Du ihr zu den anderen Katzen zu kommen?.\n" +
        "Deine Aufgabe ist es, Emma zu den anderen Katzen(Haus) zu ziehen wenn du Emma siehst.\n" +
        "Das ist ein Schiff. Hilfst du dem Schiff aus Meer zu finden. Deine Aufgabe ist es, das Schiff auf das Meer zu bringen, wenn du das Schiff siehst.\n " +
        "Los geht's!";
    Sprite BLUE_EMMA;
    Sprite BLUE_LUNA;
    Sprite ORANGE_LUNA;
    Sprite ORANGE_EMMA;
    Vector3 SPRITE_DEFAULT_POS;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        stimulus = GameObject.Find("Stimulus_1");
        trialCounter = GameObject.Find("TrialCounter_1");
        starPanel = GameObject.Find("StarPanel1");
        text = GameObject.Find("StarAmount_1");
        starPanel.SetActive(true);
        setText();
         //choose sprite according to level page
        if(GameManager.get().getPage() == 0){
            BLUE_EMMA = Resources.Load<Sprite>("blue_emma");
            ORANGE_EMMA = Resources.Load<Sprite>("orange_emma");
            BLUE_LUNA = Resources.Load<Sprite>("blue_luna");
            ORANGE_LUNA = Resources.Load<Sprite>("orange_luna");
        }else if(GameManager.get().getPage() == 1)
        {
            BLUE_EMMA = Resources.Load<Sprite>("blue_emma");
            ORANGE_EMMA = Resources.Load<Sprite>("orange_emma");
            BLUE_LUNA = Resources.Load<Sprite>("blue_luna");
            ORANGE_LUNA = Resources.Load<Sprite>("orange_luna");
        }
        else if(GameManager.get().getPage() == 2)
        {
            BLUE_EMMA = Resources.Load<Sprite>("blue_emma");
            ORANGE_EMMA = Resources.Load<Sprite>("orange_emma");
            BLUE_LUNA = Resources.Load<Sprite>("blue_luna");
            ORANGE_LUNA = Resources.Load<Sprite>("orange_luna");
        }
        
        SPRITE_DEFAULT_POS = stimulus.transform.position;
        stars = GameObject.Find("stars_achieved");
        stars.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < numberOfTrials; i++)
        {
            int numb = Random.Range(0, 4);
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
            var clip = Resources.Load("correct") as AudioClip;
            audioSource.clip = clip;
            audioSource.Play();
            correct++;
        }
        else
        {
            //give feedback
            var clip = Resources.Load("wrong") as AudioClip;
            audioSource.clip = clip;
            audioSource.Play();
        }
        nextTrial();
    }

    private void setText()
    {
        if (colorGame)
        {
            text.GetComponent<Text>().text = COLOR_GAME_INFO;
        }
        else
        {
            text.GetComponent<Text>().text = SHAPE_GAME_INFO;
        }
    }

    public void nextTrial()
    {
        //
        trial++;
        if (trial %2 == 0 && trial != 0)
        {
            colorGame = !colorGame;
            starPanel.SetActive(true);
            setText();
            //audio
        }
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
        if (colorGame)
        {
            if (stimulusArray[trial] == 0)
            {
                //spriteRenderer.sprite = BLUE_EMMA;
                stimulus.GetComponent<Image>().sprite = BLUE_EMMA;
                isCorrectAnswerA = true;
            }
            else if (stimulusArray[trial] == 1)
            {
                //spriteRenderer.sprite = ORANGE_EMMA;
                stimulus.GetComponent<Image>().sprite = ORANGE_EMMA;
                isCorrectAnswerA = false;
            }
            else if (stimulusArray[trial] == 2)
            {
                stimulus.GetComponent<Image>().sprite = BLUE_LUNA;
                isCorrectAnswerA = true;
            }
            else
            {
                stimulus.GetComponent<Image>().sprite = ORANGE_LUNA;
                isCorrectAnswerA = false;
            }
        }
        else
        {
            if (stimulusArray[trial] == 0)
            {
                stimulus.GetComponent<Image>().sprite = BLUE_EMMA;
                isCorrectAnswerA = true;
            }
            else if (stimulusArray[trial] == 1)
            {
                stimulus.GetComponent<Image>().sprite = ORANGE_EMMA;
                isCorrectAnswerA = true;
            }
            else if (stimulusArray[trial] == 2)
            {
                stimulus.GetComponent<Image>().sprite = BLUE_LUNA;
                isCorrectAnswerA = false;
            }
            else
            {
                stimulus.GetComponent<Image>().sprite = ORANGE_LUNA;
                isCorrectAnswerA = false;
            }
        }
        //reset stimulus to origin position
        stimulus.transform.position = SPRITE_DEFAULT_POS;
    }

    public void finish()
    {
        //return to level page
        if (correct == numberOfTrials && level + 6 * GameManager.get().getPage() == GameManager.get().getLevel())
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
        string number = getCorrect().ToString();
        string max = getTrials().ToString();
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
