using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [NonSerialized]
    public int scoreA;
    void Start()
    {
        scoreA = 0;
    }

    public void AddScore(int score)
    {
        scoreA += score;
    }
    public int score{ get { return scoreA; } 
    }
}
