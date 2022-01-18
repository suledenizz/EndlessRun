using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    Text scoreText;
    GameSession gameSession;

    // Use this for initialization
    public void Start () {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    public void Update () {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
