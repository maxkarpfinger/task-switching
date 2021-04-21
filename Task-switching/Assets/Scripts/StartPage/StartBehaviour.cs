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
        SceneManager.LoadScene("LevelPage");
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
}
