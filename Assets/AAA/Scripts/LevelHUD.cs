using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHUD : MonoBehaviour
{
    public static LevelHUD instance;
    [SerializeField]
    private Text scoreText;
    private Score score;
    void Awake()
    {
        scoreText = FindObjectOfType<Text>();
        if (scoreText ==null )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        instance = this;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void FinishScene()
    {
        
        SceneManager.LoadScene(2);
        //ShowScore();
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    void ShowScore()
    {
        scoreText.text = Score.instance.score.ToString();
    }
}
