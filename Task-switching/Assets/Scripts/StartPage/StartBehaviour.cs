using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
    {
        //switch to Level page
        if(GameManager.get().getStarts() > 1)
        {
            SceneManager.LoadScene("LevelPage");
        }
        else
        {
            GameManager.get().setStarts(2);
            SceneManager.LoadScene("Tutorial");
        }
        
    }
	
    public void OnImpressumPress()
    {
	    //switch to Impressum page
	    SceneManager.LoadScene("ImpressumPage");
    }

    public void OnPartyPress()
    {
        //switch to Party page
        SceneManager.LoadScene("PartyPage");
    }

    public void OnExitPress()
    {
        //switch to Exit page
        SceneManager.LoadScene("ExitPage");
    }
}
