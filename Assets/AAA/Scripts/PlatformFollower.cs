using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;

public class PlatformFollower : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Spline spline;

    [SerializeField]
    private float distance;

    [SerializeField] 
    private float speed = 5f;
    
    
    void Start()
    {
        
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
}
