using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    Text scoreText;


    public void Start () {
        scoreText = GetComponent<Text>();
    }
    
    public void Update () {
        scoreText.text = GameSession.instance.GetScore().ToString();
    }
}
