using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBehaviour : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("ResetConfirmPanel");
        panel.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
           
    }

    public void OnButtonPress()
    {
        // reset game advancement counter i.e. level counter
        // prompt user if they really want to reset
        panel.SetActive(true);
    }
}
