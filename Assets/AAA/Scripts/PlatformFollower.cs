using System;
using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;
using UnityEngine.Serialization;
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

    [FormerlySerializedAs("scoreAmount")] [SerializeField]
    private int scoreValue = 10;

    [SerializeField] private AudioClip pickUp;
    private DisplayScore displayScore;
    private LevelHUD level;
    

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
        if(other.gameObject.CompareTag("Kegel"))
        {
            AudioSource.PlayClipAtPoint(pickUp, transform.position);
            other.gameObject.SetActive(false);
            StartCoroutine(Active(other));
            GameSession.instance.AddToScore(scoreValue);
        }

        if (other.gameObject.CompareTag("Speed"))
        {
            speed = 7;
            StartCoroutine(ChangeSpeed());
        }
        
        if (other.gameObject.CompareTag("Slow"))
        {
            speed = 1f;
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
