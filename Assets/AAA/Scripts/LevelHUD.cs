using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHUD : MonoBehaviour
{
    public static LevelHUD instance;
    private Score score;
    void Awake()
    {
        instance = this;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void FinishScene()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
