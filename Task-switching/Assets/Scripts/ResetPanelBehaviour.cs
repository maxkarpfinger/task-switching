using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPanelBehaviour : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("ResetConfirmPanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReset()
    {
        panel.SetActive(false);
        GameObject.Find("GameManager").GetComponent<GameManager>().reset();
    }

    public void OnCancel()
    {
        panel.SetActive(false);
    }
}
