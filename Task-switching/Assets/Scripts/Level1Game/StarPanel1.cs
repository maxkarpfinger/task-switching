using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarPanel1 : MonoBehaviour
{
    public GameObject panel;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("StarOk_1");
        panel = GameObject.Find("StarPanel1");
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show()
    {
        string prefix = "Du hast ";
        string mid = " von ";
        string suffix = " Sternen bekommen!";
        string number = GameObject.Find("Level1Manager").GetComponent<Level1Game>().getCorrect().ToString();
        string max = GameObject.Find("Level1Manager").GetComponent<Level1Game>().getTrials().ToString();
        text.GetComponent<Text>().text = prefix + number + mid + max + suffix;
        panel.SetActive(true);
    }

}
