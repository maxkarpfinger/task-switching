using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Level4Game : MonoBehaviour
{
    int trial = 0;
    int correct = 0;
    int level = 3;
    static int numberOfTrials = 8;
    int[] stimulusArray = new int[numberOfTrials];
    bool colorGame = false;
    bool isCorrectAnswerA = true;
    bool isSelectedA = true;
    GameObject stimulus;
    GameObject targetA;
    GameObject targetB;
    GameObject starPanel;
    GameObject text;
    GameObject stars;
    GameObject mode;
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
        starPanel = GameObject.Find("StarPanel1");
        text = GameObject.Find("StarAmount_1");
        starPanel.SetActive(false);
        targetA = GameObject.Find("TargetA_1");
        targetB = GameObject.Find("TargetB_1");
        mode = GameObject.Find("Mode_Stimulus");
        //choose sprite according to level page
        if (GameManager.get().getPage() == 0)
        {
            BLUE_EMMA = Resources.Load<Sprite>("blue_emma");
            ORANGE_EMMA = Resources.Load<Sprite>("orange_emma");
            BLUE_LUNA = Resources.Load<Sprite>("blue_luna");
            ORANGE_LUNA = Resources.Load<Sprite>("orange_luna");
            targetA.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_target_cat");
            targetB.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_target_dog");
        }
        else if (GameManager.get().getPage() == 1)
        {
            BLUE_EMMA = Resources.Load<Sprite>("blue_cupcake");
            ORANGE_EMMA = Resources.Load<Sprite>("orange_cupcake");
            BLUE_LUNA = Resources.Load<Sprite>("blue_cake");
            ORANGE_LUNA = Resources.Load<Sprite>("orange_cake");
            targetA.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_target_cupcake");
            targetB.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_target_cake");
        }
        else if (GameManager.get().getPage() == 2)
        {
            BLUE_EMMA = Resources.Load<Sprite>("blue_balloon");
            ORANGE_EMMA = Resources.Load<Sprite>("orange_balloon");
            BLUE_LUNA = Resources.Load<Sprite>("blue_partyhat");
            ORANGE_LUNA = Resources.Load<Sprite>("orange_partyhat");
            targetA.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_target_balloon");
            targetB.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_target_partyhat");

        }

        SPRITE_DEFAULT_POS = stimulus.transform.position;
        stars = GameObject.Find("stars_achieved");
        //stars.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < numberOfTrials; i++)
        {
            int numb = Random.Range(0, 4);
            stimulusArray[i] = numb;
        }

        var clip = Resources.Load("shape_game") as AudioClip;
        audioSource.clip = clip;
        audioSource.Play();

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

    private IEnumerator StartMethod(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        var clip = Resources.Load("color_game") as AudioClip;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void nextTrial()
    {
        //
        trial++;
        if (trial == 4)
        {
            colorGame = !colorGame;
            //starPanel.SetActive(true);
            //setText();
            //audio
            StartCoroutine(StartMethod(0.35F));

        }
        if (trial >= numberOfTrials)
        {
            showStars();
            return;
        }
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
            mode.GetComponent<Image>().sprite = Resources.Load<Sprite>("color_palette");
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
            mode.GetComponent<Image>().sprite = Resources.Load<Sprite>("shape");
        }
        //reset stimulus to origin position
        stimulus.transform.position = SPRITE_DEFAULT_POS;
    }

    public void finish(bool backToMenu)
    {
        //return to level page
        if (correct * 1.0 / numberOfTrials >= 0.75 && level + 6 * GameManager.get().getPage() == GameManager.get().getLevel())
        {
            GameManager.get().incrementProgress();
        }
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
                stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_elephant");
                break;
            case 1:
                stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("cupcake4_sticker");
                break;
            case 2:
                stars.GetComponent<Image>().sprite = Resources.Load<Sprite>("hats1_sticker");
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

        //text.GetComponent<Text>().text = prefix + number + mid + max + suffix;

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
