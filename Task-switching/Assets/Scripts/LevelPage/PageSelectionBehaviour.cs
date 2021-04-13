using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSelectionBehaviour : MonoBehaviour
{
    public void OnLeft(){
        GameManager.get().decrementPage();
        LevelPageManager mgr = new LevelPageManager();
        mgr.refreshLevelButtons();
    }

    public void OnRight(){
        GameManager.get().incrementPage();
        LevelPageManager mgr = new LevelPageManager();
        mgr.refreshLevelButtons();
    }
}
