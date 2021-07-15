using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPageManager : MonoBehaviour
{
    //GameObject levelPageManager;
    AudioSource audioSource;

    void Start(){
        refreshLevelButtons();
        audioSource = GetComponent<AudioSource>();
    }

    public void playResetSound()
    {
        //audioSource = GetComponent<AudioSource>();
        var clip = Resources.Load("reset_sound") as AudioClip;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void refreshLevelButtons(){
        GameObject sticker1 = GameObject.Find("Sticker1");
        GameObject sticker2 = GameObject.Find("Sticker2");
        GameObject sticker3 = GameObject.Find("Sticker3");
        GameObject sticker4 = GameObject.Find("Sticker4");
        GameObject sticker5 = GameObject.Find("Sticker5");
        GameObject sticker6 = GameObject.Find("Sticker6");
        GameObject[] stickers = {sticker1, sticker2, sticker3, sticker4, sticker5, sticker6};
        GameObject[] levelButtons = { GameObject.Find("Level1Button"), GameObject.Find("Level2Button"), GameObject.Find("Level3Button"), GameObject.Find("Level4Button"), GameObject.Find("Level5Button"), GameObject.Find("Level6Button") };
        if(GameManager.get().getPage() == 2){
            // decoration page
            sticker1.GetComponent<Image>().sprite = Resources.Load<Sprite>("balloon1_sticker");
            sticker2.GetComponent<Image>().sprite = Resources.Load<Sprite>("balloon2_sticker");
            sticker3.GetComponent<Image>().sprite = Resources.Load<Sprite>("balloon3_sticker");
            sticker4.GetComponent<Image>().sprite = Resources.Load<Sprite>("hats1_sticker");
            sticker5.GetComponent<Image>().sprite = Resources.Load<Sprite>("hats2_sticker");
            sticker6.GetComponent<Image>().sprite = Resources.Load<Sprite>("hats3_sticker");
        }
        else if(GameManager.get().getPage() == 1){
            // food page
            sticker1.GetComponent<Image>().sprite = Resources.Load<Sprite>("cupcake1_sticker");
            sticker2.GetComponent<Image>().sprite = Resources.Load<Sprite>("cupcake2_sticker");
            sticker3.GetComponent<Image>().sprite = Resources.Load<Sprite>("cupcake3_sticker");
            sticker4.GetComponent<Image>().sprite = Resources.Load<Sprite>("cupcake4_sticker");
            sticker5.GetComponent<Image>().sprite = Resources.Load<Sprite>("cupcake5_sticker");
            sticker6.GetComponent<Image>().sprite = Resources.Load<Sprite>("cake_sticker");
        }else{
            // friends page as default
            sticker1.GetComponent<Image>().sprite = Resources.Load<Sprite>("lion_sticker");
            sticker2.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_giraffe");
            sticker3.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_elephant");
            sticker4.GetComponent<Image>().sprite = Resources.Load<Sprite>("blue_elephant");
            sticker5.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange_giraffe");
            sticker6.GetComponent<Image>().sprite = Resources.Load<Sprite>("presents");
        }

        // make locked level not interactable
        for(int i = 0; i < 6; i++){
                if(i + GameManager.get().getPage() * 6 > GameManager.get().getLevel()){
                    levelButtons[i].GetComponent<Button>().interactable = false;
                }
                else{
                    levelButtons[i].GetComponent<Button>().interactable = true;
                }
        }

        // make stickers colorful
        for (int i = 0; i < 6; i++)
        {
            if (i + GameManager.get().getPage() * 6 >= GameManager.get().getLevel())
            {
                stickers[i].GetComponent<Image>().color = UnityEngine.Color.black;
            }
            else
            {
                stickers[i].GetComponent<Image>().color = UnityEngine.Color.white;
            }
        }

        // make page selection buttons available/unavailable
        if(GameManager.get().getPage() == 0){
            GameObject.Find("RightPage").GetComponent<Button>().interactable = true;
            GameObject.Find("LeftPage").GetComponent<Button>().interactable = false;
        }
        if(GameManager.get().getPage() == 1){
            GameObject.Find("RightPage").GetComponent<Button>().interactable = true;
            GameObject.Find("LeftPage").GetComponent<Button>().interactable = true;
        }
        if(GameManager.get().getPage() == 2){
            GameObject.Find("RightPage").GetComponent<Button>().interactable = false;
            GameObject.Find("LeftPage").GetComponent<Button>().interactable = true;
        }

        // change sprites of navigation buttons
        if (GameManager.get().getPage() == 0)
        {
            GameObject.Find("RightPage").GetComponent<Image>().sprite = Resources.Load<Sprite>("cake_navigation");
            GameObject.Find("LeftPage").GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
        }
        if (GameManager.get().getPage() == 1)
        {
            GameObject.Find("RightPage").GetComponent<Image>().sprite = Resources.Load<Sprite>("deco_navigation");
            GameObject.Find("LeftPage").GetComponent<Image>().sprite = Resources.Load<Sprite>("lion_navigation");
            GameObject.Find("LeftPage").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            GameObject.Find("RightPage").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        if (GameManager.get().getPage() == 2)
        {      
            GameObject.Find("RightPage").GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
            GameObject.Find("LeftPage").GetComponent<Image>().sprite = Resources.Load<Sprite>("cake_navigation");
        }

    }

}
