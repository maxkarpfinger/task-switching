using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPracticeNavigation : MonoBehaviour
{
    public void OnReload()
    {
        SceneManager.LoadScene("LevelPractice");
    }

    public void OnNext()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnLevelPage()
    {
        SceneManager.LoadScene("LevelPage");
    }
}
