using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPageManager : MonoBehaviour
{
    //GameObject levelPageManager;

    void Start(){
        refreshLevelButtons();
    }

    public void refreshLevelButtons(){
        Debug.Log("refreshLevelButtons");
        GameObject level1 = GameObject.Find("Level1Button");
        GameObject level2 = GameObject.Find("Level2Button");
        GameObject level3 = GameObject.Find("Level3Button");
        GameObject level4 = GameObject.Find("Level4Button");
        GameObject level5 = GameObject.Find("Level5Button");
        GameObject level6 = GameObject.Find("Level6Button");
        GameObject[] levelButtons = {level1, level2, level3, level4, level5, level6};
        if(GameManager.get().getPage() == 2){
            // decoration page
            level1.GetComponent<Image>().sprite = Resources.Load<Sprite>("level1");
            level2.GetComponent<Image>().sprite = Resources.Load<Sprite>("level2deco");
            level3.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3deko");
            level4.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3deko");
            level5.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3deko");
            level6.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3deko");
        }
        else if(GameManager.get().getPage() == 1){
            // food page
            level1.GetComponent<Image>().sprite = Resources.Load<Sprite>("level1");
            level2.GetComponent<Image>().sprite = Resources.Load<Sprite>("level2_food");
            level3.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3food");
            level4.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3food");
            level5.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3food");
            level6.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3food");
        }else{
            // friends page as default
            level1.GetComponent<Image>().sprite = Resources.Load<Sprite>("level1");
            level2.GetComponent<Image>().sprite = Resources.Load<Sprite>("level2");
            level3.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3");
            level4.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3");
            level5.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3");
            level6.GetComponent<Image>().sprite = Resources.Load<Sprite>("level3");
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

        // make page selection buttons available/unavailable
        Debug.Log("Page is: "+GameManager.get().getPage());
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

    }

}
