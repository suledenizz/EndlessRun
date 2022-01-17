using System;
using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;
using UnityEngine.UI;

public class PlatformFollower : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Spline spline;

    [SerializeField]
    private float distance;

    [SerializeField] 
    private float speed = 2f;

    [SerializeField]
    private int scoreAmount = 10;
    
    [SerializeField]
    private Text scoreText;

    private Score score;
    private LevelHUD level;
    
    
    void Start()
    {
        score = FindObjectOfType<Score>();

    }

    // Update is called once per frame
    void Update()
    {
        float distanceThisFrame = speed * Time.deltaTime;
        distance += distanceThisFrame;
        if (distance <= spline.Length)
        {
            //follow path all the time when it reached at the end
            FollowPath();
        }
        else
        {
            distance = 0;
        }
        
    }

    void FollowPath()
    {
        var curveSample = spline.BetterSampleAtDistance(distance);
        player.position = curveSample.WorldLocation;
        player.rotation = curveSample.WorldRotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Kegel")
        {
            other.gameObject.SetActive(false);
            StartCoroutine(Active(other));
            //other.gameObject.SetActive(true);
            score.AddScore(scoreAmount);
            scoreText.text = score.score.ToString();
        }

        if (other.gameObject.tag == "Speed")
        {
            speed = 10;
            StartCoroutine(ChangeSpeed());
        }
        
        if (other.gameObject.tag == "Slow")
        {
            speed = 0.75f;
            StartCoroutine(ChangeSpeed());
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Finish();
        }
    }
    

    IEnumerator Active(Collider kegel)
    {
        
        yield return new  WaitForSeconds(5);
        kegel.gameObject.SetActive(true);
    }

    IEnumerator ChangeSpeed()
    {
        yield return new WaitForSeconds(3);
        speed = 2f;
    }
    

    void Finish()
    {
        LateralMover.instance.enabled = false;
        enabled = false;
        speed = 0;
        LevelHUD.instance.FinishScene();
    }
}
