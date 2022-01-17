using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    [NonSerialized]
    public int scoreA;
    void Start()
    {
        instance = this;
        scoreA = 0;
    }

    public void AddScore(int score)
    {
        scoreA += score;
    }
    public int score{ get { return scoreA; } 
    }
}
