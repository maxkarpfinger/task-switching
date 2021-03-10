using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GameManager.get().reset();
        SceneManager.LoadScene("LevelPage");
    }

    public void OnCancel()
    {
        panel.SetActive(false);
    }
}
