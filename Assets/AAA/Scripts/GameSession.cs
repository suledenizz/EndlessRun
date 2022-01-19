using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static int score=0;
    public static GameSession instance;

    private void Awake()
    {
        instance = this;
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    } 
    
    public int GetScore()
    {
        return score;
    }
    public void ResetGame()
    {
        score = 0;
        Destroy(this.gameObject);
    }

}
