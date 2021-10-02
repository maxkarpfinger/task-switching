using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using System.Diagnostics;
using System.IO;
using UnityEngine.Android;

public class Level1Game : MonoBehaviour
{
    int trial = 0;
    int correct = 0;
    int level = 0;
    int parentCounter = 0;
    static int numberOfTrials = 8;
    int[] stimulusArray = new int[numberOfTrials]; 
    bool isCorrectAnswerA = true;
    bool isSelectedA = true;
    GameObject stimulus;
    GameObject targetA;
    GameObject targetB;
    GameObject starPanel;
    GameObject stars;
    GameObject mode;
    GameObject parentPanel;
    GameObject parentBlueEmma;
    GameObject parentOrangeEmma;
    GameObject parentBlueLuna;
    GameObject parentOrangeLuna;
    GameObject parentCounterText;
    Sprite BLUE_EMMA; //or blue cake or blue balloon
    Sprite BLUE_LUNA; //or cupcake or blue party hat
    Sprite ORANGE_LUNA; //or orange cake or orange balloon
    Sprite ORANGE_EMMA; // or orange cupcake or orange party hat
    Vector3 SPRITE_DEFAULT_POS;
    AudioSource audioSource;
    Stopwatch timer;
    String log;

    // Start is called before the first frame update
    void Start()
    {
        stimulus = GameObject.Find("Stimulus_1");
        //spriteRenderer = GameObject.Find("blue_emma").GetComponent<SpriteRenderer>();
        targetA = GameObject.Find("TargetA_1");
        targetB = GameObject.Find("TargetB_1");
        starPanel = GameObject.Find("StarPanel1");
        mode = GameObject.Find("Mode_Stimulus");
        parentPanel = GameObject.Find("ParentPanel");
        parentBlueEmma = GameObject.Find("blue_emma");
        parentOrangeEmma = GameObject.Find("orange_emma");
        parentBlueLuna = GameObject.Find("blue_luna");
        parentOrangeLuna = GameObject.Find("orange_luna");
        parentCounterText = GameObject.Find("parentCounter");
        mode.GetComponent<Image>().sprite = Resources.Load<Sprite>("color_palette");
        starPanel.SetActive(false);
        setupTargets();
        SPRITE_DEFAULT_POS = stimulus.transform.position;
        //stars = GameObject.Find("stars_achieved");
        //stars.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        timer = new Stopwatch();
        log = "";
        for (int i=0; i<numberOfTrials; i++)
        {
            int numb = Random.Range(0, 4);
            stimulusArray[i] = numb;
        }

        parentPanel.SetActive(false);
        if(GameManager.get().isParentMode()){
            parentPanel.SetActive(true);
            parentCounterText.GetComponent<Text>().text = "0 / " + numberOfTrials + "\n ausgewählt";
            var clip = Resources.Load("selection") as AudioClip;
            audioSource.clip = clip;
            audioSource.Play();
        }
        else{
            var clip = Resources.Load("color_game") as AudioClip;
            audioSource.clip = clip;
            audioSource.Play();
            setupTrial();
        }
    }

    private void setupTargets(){
        //choose sprite according to level page
        if(GameManager.get().getPage() == 0)
        {
            BLUE_EMMA = Resources.Load<Sprite>("blue_emma");
            ORANGE_EMMA = Resources.Load<Sprite>("orange_emma");
            BLUE_LUNA = Resources.Load<Sprite>("blue_luna");
            ORANGE_LUNA = Resources.Load<Sprite>("orange_luna");
            targetA.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_target_cat");
            targetB.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_target_dog");

            parentBlueEmma.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_emma");
            parentOrangeEmma.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_emma");
            parentBlueLuna.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_luna");
            parentOrangeLuna.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_luna");
        }else if(GameManager.get().getPage() == 1)
        {
            BLUE_EMMA = Resources.Load<Sprite>("blue_cupcake");
            ORANGE_EMMA = Resources.Load<Sprite>("orange_cupcake");
            BLUE_LUNA = Resources.Load<Sprite>("blue_cake");
            ORANGE_LUNA = Resources.Load<Sprite>("orange_cake");
            targetA.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_target_cupcake");
            targetB.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_target_cake");

            parentBlueEmma.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_cupcake");
            parentOrangeEmma.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_cupcake");
            parentBlueLuna.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_cake");
            parentOrangeLuna.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_cake");
        }
        else if(GameManager.get().getPage() == 2)
        {
            BLUE_EMMA = Resources.Load<Sprite>("blue_balloon");
            ORANGE_EMMA = Resources.Load<Sprite>("orange_balloon");
            BLUE_LUNA = Resources.Load<Sprite>("blue_partyhat");
            ORANGE_LUNA = Resources.Load<Sprite>("orange_partyhat");
            targetA.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_target_balloon");
            targetB.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_target_partyhat");

            parentBlueEmma.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_balloon");
            parentOrangeEmma.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_balloon");
            parentBlueLuna.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_partyhat");
            parentOrangeLuna.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_partyhat");
        }
    }

    public void checkCorrectnes()
    {
        bool trialIsCorrect = isCorrectAnswerA && isSelectedA || !isCorrectAnswerA && !isSelectedA;
        //stop timer
        timer.Stop();
        double elapsed = Math.Round(timer.Elapsed.TotalMilliseconds);
        log += elapsed + "," + (trial + 1) + ",1," + Convert.ToInt32(trialIsCorrect) + ",1," + stimulusArray[trial] + "," + (GameManager.get().getPage() + 1) + "," + Convert.ToInt32(GameManager.get().isParentMode());
        if (trial + 1 < numberOfTrials) {
            log += "\n";
        }
        timer = new Stopwatch();
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

    public void nextTrial()
    {
        trial++;
        if(trial >= numberOfTrials)
        {
            //UnityEngine.Debug.Log(log);            
            if (Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            {
                string path = Application.persistentDataPath + "log.txt";
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(log);
                }
            }
            showStars();
            return;
        }
        setupTrial();
    }

    public void setupTrial()
    {
        //start timer for trial
        timer.Start();
        //set correct answer and update stimulus
        //only color game
        if (stimulusArray[trial] == 0)
        {
            //spriteRenderer.sprite = BLUE_EMMA;
            stimulus.GetComponent<Image>().sprite = BLUE_EMMA;
            isCorrectAnswerA = true;
        }else if(stimulusArray[trial] == 1){
            //spriteRenderer.sprite = ORANGE_EMMA;
            stimulus.GetComponent<Image>().sprite = ORANGE_EMMA;
            isCorrectAnswerA = false;
        }else if(stimulusArray[trial] == 2){
            stimulus.GetComponent<Image>().sprite = BLUE_LUNA;
            isCorrectAnswerA = true;
        }
        else
        {
            stimulus.GetComponent<Image>().sprite = ORANGE_LUNA;
            isCorrectAnswerA = false;
        }
        //reset stimulus to origin position
        stimulus.transform.position = SPRITE_DEFAULT_POS;
    }

    public void finish(bool backToMenu)
    {
        
        if (correct * 1.0 / numberOfTrials >= 0.75 && level + 6 * GameManager.get().getPage() == GameManager.get().getLevel())
        {
           GameManager.get().incrementProgress();
        }
        //return to level page
        if (backToMenu)
        {
            SceneManager.LoadScene("LevelPage");
        }
        
    }

    public void showStars()
    {
        //display number of won stars
        //also give audio feedback
        int page = GameManager.get().getPage();
        starPanel.SetActive(true);
        stars = GameObject.Find("stars_achieved");
        stars.SetActive(true);

        GameObject nextLevel = GameObject.Find("next_level");
        GameObject.Find("Back").GetComponent<Button>().interactable = false;

        switch (page)
        {
            case 0:
                stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("lion_sticker");
                break;
            case 1:
                stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("cupcake1_sticker");
                break;
            case 2:
                stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("balloon1_sticker");
                break;
            default:
                stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("lion_sticker");
                break;
        }

        if (level + 6 * GameManager.get().getPage() < GameManager.get().getLevel())
        {
            //revisiting this level           
            if (correct * 1.0 / numberOfTrials >= 0.75)
            {
                // case when sticker has already been unlocked but would be unlocked again (lower level replayed)
                stars.GetComponent<Image>().color = UnityEngine.Color.white;
                var clip = Resources.Load("sticker_already_won") as AudioClip;
                audioSource.clip = clip;
                audioSource.Play();
                nextLevel.GetComponent<Button>().interactable = true;
            }
            else
            {
                // case when sticker has already been unlocked but would NOT be unlocked again (lower level replayed)
                stars.GetComponent<Image>().color = UnityEngine.Color.white;
                var clip = Resources.Load("sticker_already_lose") as AudioClip;
                audioSource.clip = clip;
                audioSource.Play();
                nextLevel.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            if (correct * 1.0 / numberOfTrials >= 0.75)
            {
                // case when sticker has not been unlocked yet
                stars.GetComponent<Image>().color = UnityEngine.Color.white;
                var clip = Resources.Load("sticker_won") as AudioClip;
                audioSource.clip = clip;
                audioSource.Play();
                nextLevel.GetComponent<Button>().interactable = true;
            }
            else
            {
                // case when sticker is still locked
                var clip = Resources.Load("sticker_lose") as AudioClip;
                audioSource.clip = clip;
                audioSource.Play();
                stars.GetComponent<Image>().color = UnityEngine.Color.black;
                nextLevel.GetComponent<Button>().interactable = false;
            }
        }
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

    public void setTrial(int stimulus){
        stimulusArray[parentCounter++] = stimulus;
        String output = "" + parentCounter + " / " + numberOfTrials + "\n ausgewählt";
        parentCounterText.GetComponent<Text>().text = output;
        if (parentCounter == numberOfTrials)
        {
            setupTrial();
            var clip = Resources.Load("color_game") as AudioClip;
            audioSource.clip = clip;
            audioSource.Play();
            GameObject.Find("ParentPanel").SetActive(false);
        }
    }


}
